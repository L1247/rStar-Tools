#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.MethodInvoker
{
    [Serializable]
    public class MethodContainer
    {
    #region Public Variables

        [HideInInspector]
        public GameObject targetGameObject;

        [ListDrawerSettings(IsReadOnly = true , HideAddButton = true , Expanded = true)]
        public List<MethodEntry> methodEntries = new List<MethodEntry>();

    #endregion

    #region Constructor

        public MethodContainer(GameObject target)
        {
            targetGameObject = target;
            RefreshEntries();
        }

    #endregion

    #region Public Methods

        public void RefreshEntries()
        {
            methodEntries.Clear();
            if (targetGameObject == null) return;
            var monoBehaviours = targetGameObject.GetComponents<MonoBehaviour>();
            if (monoBehaviours.Length > 0)
                foreach (var monoBehaviour in monoBehaviours)
                {
                    var type        = monoBehaviour.GetType();
                    var methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    foreach (var methodInfo in methodInfos)
                    {
                        if (methodInfo.ReturnType != typeof(void))
                            continue;
                        var info        = new DelegateInfo { Method = methodInfo , Target = monoBehaviour };
                        var newDelegate = CreateAndAssignNewDelegate(info);
                        methodEntries.Add(new MethodEntry(newDelegate));
                    }
                }
        }

    #endregion

    #region Private Methods

        private Delegate CreateAndAssignNewDelegate(DelegateInfo delInfo)
        {
            var method = delInfo.Method;
            var target = delInfo.Target;
            var pTypes = method.GetParameters().Select(x => x.ParameterType).ToArray();
            var args   = new object[pTypes.Length];

            Type delegateType = null;

            if (method.ReturnType == typeof(void))
            {
                if (args.Length == 0) delegateType      = typeof(Action);
                else if (args.Length == 1) delegateType = typeof(Action<>).MakeGenericType(pTypes);
                else if (args.Length == 2) delegateType = typeof(Action<,>).MakeGenericType(pTypes);
                else if (args.Length == 3) delegateType = typeof(Action<, ,>).MakeGenericType(pTypes);
                else if (args.Length == 4) delegateType = typeof(Action<, , ,>).MakeGenericType(pTypes);
                else if (args.Length == 5) delegateType = typeof(Action<, , , ,>).MakeGenericType(pTypes);
            }
            else
            {
                pTypes = pTypes.Append(method.ReturnType).ToArray();
                if (args.Length == 0) delegateType      = typeof(Func<>).MakeArrayType();
                else if (args.Length == 1) delegateType = typeof(Func<,>).MakeGenericType(pTypes);
                else if (args.Length == 2) delegateType = typeof(Func<, ,>).MakeGenericType(pTypes);
                else if (args.Length == 3) delegateType = typeof(Func<, , ,>).MakeGenericType(pTypes);
                else if (args.Length == 4) delegateType = typeof(Func<, , , ,>).MakeGenericType(pTypes);
                else if (args.Length == 5) delegateType = typeof(Func<, , , , ,>).MakeGenericType(pTypes);
            }

            if (delegateType == null)
            {
                Debug.LogError("Unsupported Method Type");
                return null;
            }

            var del = Delegate.CreateDelegate(delegateType , target , method);

            return del;
        }

    #endregion
    }
}