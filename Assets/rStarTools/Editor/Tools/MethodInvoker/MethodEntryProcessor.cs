#region

using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

#endregion

namespace rStarTools.MethodInvoker
{
    public class MethodEntryProcessor : OdinPropertyProcessor<MethodEntry>
    {
    #region Private Variables

        private class ArrayIndexGetterSetter<T> : IValueGetterSetter<object , T>
        {
        #region Public Variables

            public bool IsReadonly => false;

            public object[] parameterValues
            {
                get
                {
                    var val = (MethodEntry)property.ValueEntry.WeakSmartValue;
                    return val.ParameterValues;
                }
            }

            public Type OwnerType => typeof(object);

            public Type ValueType => typeof(T);

        #endregion

        #region Private Variables

            private readonly InspectorProperty property;
            private readonly int               index;

        #endregion

        #region Constructor

            public ArrayIndexGetterSetter(InspectorProperty property , int index)
            {
                this.property = property;
                this.index    = index;
            }

        #endregion

        #region Public Methods

            public T GetValue(ref object owner)
            {
                var parms = parameterValues;
                if (parms == null || index >= parms.Length) return default(T);

                if (parms[index] == null) return default(T);

                try
                {
                    return (T)parms[index];
                }
                catch
                {
                    return default(T);
                }
            }

            public object GetValue(object owner)
            {
                var parms = parameterValues;
                if (parms == null || index >= parms.Length) return default(T);

                return parameterValues[index];
            }

            public void SetValue(ref object owner , T value)
            {
                var parms = parameterValues;
                if (parms == null || index >= parms.Length) return;

                parms[index] = value;
            }

            public void SetValue(object owner , object value)
            {
                var parms = parameterValues;
                if (parms == null || index >= parms.Length) return;

                parms[index] = value;
            }

        #endregion
        }

    #endregion

    #region Public Methods

        public override void ProcessMemberProperties(List<InspectorPropertyInfo> propertyInfos)
        {
            var val = (MethodEntry)Property.ValueEntry.WeakSmartValue;
            if (val.Delegate == null) return;
            if (val.Delegate.Method == null) return;

            var ps = val.Delegate.Method.GetParameters();
            if (ps.Length != 0)
            {
                var maxLength = ps.ToList().Max(info => info.Name.Length);
                for (var i = 0 ; i < ps.Length ; i++)
                {
                    var p                = ps[i];
                    var getterSetterType = typeof(ArrayIndexGetterSetter<>).MakeGenericType(p.ParameterType);
                    var getterSetter =
                        Activator.CreateInstance(getterSetterType , Property , i) as IValueGetterSetter;
                    var info = InspectorPropertyInfo.CreateValue(p.Name , i , SerializationBackend.Odin , getterSetter ,
                                                                 new LabelWidthAttribute(maxLength * 6 + 20));
                    propertyInfos.Add(info);
                }
            }

            propertyInfos.AddDelegate("Invoke" , () =>
            {
                var parameterValues                                      = new object[ps.Length];
                for (var i = 0 ; i < ps.Length ; i++) parameterValues[i] = propertyInfos[i].GetGetterSetter().GetValue(val);
                val.Delegate.Method.Invoke(val.Delegate.Target , parameterValues);
            } , ps.Length);
        }

    #endregion
    }
}