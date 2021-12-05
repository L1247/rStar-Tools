#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace UniRx
{
    public struct CollectionAddEvent<T> : IEquatable<CollectionAddEvent<T>>
    {
        public int Index { get; }
        public T   Value { get; }

        public CollectionAddEvent(int index , T value)
            : this()
        {
            Index = index;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("Index:{0} Value:{1}" , Index , Value);
        }

        public override int GetHashCode()
        {
            return Index.GetHashCode() ^ (EqualityComparer<T>.Default.GetHashCode(Value) << 2);
        }

        public bool Equals(CollectionAddEvent<T> other)
        {
            return Index.Equals(other.Index) && EqualityComparer<T>.Default.Equals(Value , other.Value);
        }
    }

    public struct CollectionRemoveEvent<T> : IEquatable<CollectionRemoveEvent<T>>
    {
        public int Index { get; }
        public T   Value { get; }

        public CollectionRemoveEvent(int index , T value)
            : this()
        {
            Index = index;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("Index:{0} Value:{1}" , Index , Value);
        }

        public override int GetHashCode()
        {
            return Index.GetHashCode() ^ (EqualityComparer<T>.Default.GetHashCode(Value) << 2);
        }

        public bool Equals(CollectionRemoveEvent<T> other)
        {
            return Index.Equals(other.Index) && EqualityComparer<T>.Default.Equals(Value , other.Value);
        }
    }

    public struct CollectionMoveEvent<T> : IEquatable<CollectionMoveEvent<T>>
    {
        public int OldIndex { get; }
        public int NewIndex { get; }
        public T   Value    { get; }

        public CollectionMoveEvent(int oldIndex , int newIndex , T value)
            : this()
        {
            OldIndex = oldIndex;
            NewIndex = newIndex;
            Value    = value;
        }

        public override string ToString()
        {
            return string.Format("OldIndex:{0} NewIndex:{1} Value:{2}" , OldIndex , NewIndex , Value);
        }

        public override int GetHashCode()
        {
            return OldIndex.GetHashCode() ^ (NewIndex.GetHashCode() << 2) ^
                   (EqualityComparer<T>.Default.GetHashCode(Value) >> 2);
        }

        public bool Equals(CollectionMoveEvent<T> other)
        {
            return OldIndex.Equals(other.OldIndex) && NewIndex.Equals(other.NewIndex) &&
                   EqualityComparer<T>.Default.Equals(Value , other.Value);
        }
    }

    public struct CollectionReplaceEvent<T> : IEquatable<CollectionReplaceEvent<T>>
    {
        public int Index    { get; }
        public T   OldValue { get; }
        public T   NewValue { get; }

        public CollectionReplaceEvent(int index , T oldValue , T newValue)
            : this()
        {
            Index    = index;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return string.Format("Index:{0} OldValue:{1} NewValue:{2}" , Index , OldValue , NewValue);
        }

        public override int GetHashCode()
        {
            return Index.GetHashCode() ^ (EqualityComparer<T>.Default.GetHashCode(OldValue) << 2) ^
                   (EqualityComparer<T>.Default.GetHashCode(NewValue) >> 2);
        }

        public bool Equals(CollectionReplaceEvent<T> other)
        {
            return Index.Equals(other.Index)
                   && EqualityComparer<T>.Default.Equals(OldValue , other.OldValue)
                   && EqualityComparer<T>.Default.Equals(NewValue , other.NewValue);
        }
    }

    // IReadOnlyList<out T> is from .NET 4.5
    public interface IReadOnlyReactiveCollection<T> : IEnumerable<T>
    {
        int Count { get; }
        T this[int index] { get; }
        IObservable<CollectionAddEvent<T>>     ObserveAdd();
        IObservable<int>                       ObserveCountChanged(bool notifyCurrentCount = false);
        IObservable<CollectionMoveEvent<T>>    ObserveMove();
        IObservable<CollectionRemoveEvent<T>>  ObserveRemove();
        IObservable<CollectionReplaceEvent<T>> ObserveReplace();
        IObservable<Unit>                      ObserveReset();
    }

    public interface IReactiveCollection<T> : IList<T> , IReadOnlyReactiveCollection<T>
    {
        new int Count { get; }
        new T this[int index] { get; set; }
        void Move(int  oldIndex , int newIndex);
    }

    [Serializable]
    public class ReactiveCollection<T> : Collection<T> , IReactiveCollection<T> , IDisposable
    {
        [NonSerialized]
        private bool isDisposed = false;

        public ReactiveCollection() { }

        public ReactiveCollection(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection");

            foreach (var item in collection) Add(item);
        }

        public ReactiveCollection(List<T> list)
            : base(list != null ? new List<T>(list) : null) { }

        protected override void ClearItems()
        {
            var beforeCount = Count;
            base.ClearItems();

            if (collectionReset != null) collectionReset.OnNext(Unit.Default);
            if (beforeCount > 0)
                if (countChanged != null)
                    countChanged.OnNext(Count);
        }

        protected override void InsertItem(int index , T item)
        {
            base.InsertItem(index , item);

            if (collectionAdd != null) collectionAdd.OnNext(new CollectionAddEvent<T>(index , item));
            if (countChanged != null) countChanged.OnNext(Count);
        }

        public void Move(int oldIndex , int newIndex)
        {
            MoveItem(oldIndex , newIndex);
        }

        protected virtual void MoveItem(int oldIndex , int newIndex)
        {
            var item = this[oldIndex];
            base.RemoveItem(oldIndex);
            base.InsertItem(newIndex , item);

            if (collectionMove != null) collectionMove.OnNext(new CollectionMoveEvent<T>(oldIndex , newIndex , item));
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            base.RemoveItem(index);

            if (collectionRemove != null) collectionRemove.OnNext(new CollectionRemoveEvent<T>(index , item));
            if (countChanged != null) countChanged.OnNext(Count);
        }

        protected override void SetItem(int index , T item)
        {
            var oldItem = this[index];
            base.SetItem(index , item);

            if (collectionReplace != null)
                collectionReplace.OnNext(new CollectionReplaceEvent<T>(index , oldItem , item));
        }


        [NonSerialized]
        private Subject<int> countChanged;

        public IObservable<int> ObserveCountChanged(bool notifyCurrentCount = false)
        {
            if (isDisposed) return Observable.Empty<int>();

            var subject = countChanged ?? (countChanged = new Subject<int>());
            if (notifyCurrentCount)
                return subject.StartWith(() => Count);
            return subject;
        }

        [NonSerialized]
        private Subject<Unit> collectionReset;

        public IObservable<Unit> ObserveReset()
        {
            if (isDisposed) return Observable.Empty<Unit>();
            return collectionReset ?? (collectionReset = new Subject<Unit>());
        }

        [NonSerialized]
        private Subject<CollectionAddEvent<T>> collectionAdd;

        public IObservable<CollectionAddEvent<T>> ObserveAdd()
        {
            if (isDisposed) return Observable.Empty<CollectionAddEvent<T>>();
            return collectionAdd ?? (collectionAdd = new Subject<CollectionAddEvent<T>>());
        }

        [NonSerialized]
        private Subject<CollectionMoveEvent<T>> collectionMove;

        public IObservable<CollectionMoveEvent<T>> ObserveMove()
        {
            if (isDisposed) return Observable.Empty<CollectionMoveEvent<T>>();
            return collectionMove ?? (collectionMove = new Subject<CollectionMoveEvent<T>>());
        }

        [NonSerialized]
        private Subject<CollectionRemoveEvent<T>> collectionRemove;

        public IObservable<CollectionRemoveEvent<T>> ObserveRemove()
        {
            if (isDisposed) return Observable.Empty<CollectionRemoveEvent<T>>();
            return collectionRemove ?? (collectionRemove = new Subject<CollectionRemoveEvent<T>>());
        }

        [NonSerialized]
        private Subject<CollectionReplaceEvent<T>> collectionReplace;

        public IObservable<CollectionReplaceEvent<T>> ObserveReplace()
        {
            if (isDisposed) return Observable.Empty<CollectionReplaceEvent<T>>();
            return collectionReplace ?? (collectionReplace = new Subject<CollectionReplaceEvent<T>>());
        }

        private void DisposeSubject<TSubject>(ref Subject<TSubject> subject)
        {
            if (subject != null)
                try
                {
                    subject.OnCompleted();
                }
                finally
                {
                    subject.Dispose();
                    subject = null;
                }
        }

    #region IDisposable Support

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposeSubject(ref collectionReset);
                    DisposeSubject(ref collectionAdd);
                    DisposeSubject(ref collectionMove);
                    DisposeSubject(ref collectionRemove);
                    DisposeSubject(ref collectionReplace);
                    DisposeSubject(ref countChanged);
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

    #endregion
    }

    public static class ReactiveCollectionExtensions
    {
        public static ReactiveCollection<T> ToReactiveCollection<T>(this IEnumerable<T> source)
        {
            return new ReactiveCollection<T>(source);
        }
    }
}