#region

using System;
using System.Linq;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace rStarTools.MethodInvoker
{
    public class MethodEntryDrawer : OdinValueDrawer<MethodEntry>
    {
    #region Private Variables

        private GameObject tmpTarget;

    #endregion

    #region Protected Methods

        protected override void DrawPropertyLayout(GUIContent label)
        {
            SirenixEditorGUI.BeginBox();
            {
                var dInfo = GetDelegateInfo();
                EditorGUI.BeginChangeCheck();
                if (dInfo.Target != null)
                {
                    var methodFullName = dInfo.Method.ToString().Remove(0 , 5);

                    SirenixEditorGUI.BeginBox(methodFullName);
                    // Draws the rest of the ICustomEvent, and since we've drawn the label, we simply pass along null.
                    for (var i = 0 ; i < Property.Children.Count ; i++)
                    {
                        var child = Property.Children[i];
                        if (child.Name == "Result") continue;
                        child.Draw();
                    }

                    SirenixEditorGUI.EndBox();
                }
            }
            SirenixEditorGUI.EndBox();
        }

    #endregion

    #region Private Methods

        private void CreateAndAssignNewDelegate(DelegateInfo delInfo)
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
                return;
            }

            var del = Delegate.CreateDelegate(delegateType , target , method);
            Property.Tree.DelayActionUntilRepaint(() =>
            {
                ValueEntry.WeakSmartValue = new MethodEntry(del);
                GUI.changed               = true;
                Property.RefreshSetup();
            });
        }

        private DelegateInfo GetDelegateInfo()
        {
            var value      = ValueEntry.SmartValue;
            var del        = value.Delegate;
            var methodInfo = del == null ? null : del.Method;

            Object target = null;
            if (tmpTarget)
                target                   = tmpTarget;
            else if (del != null) target = del.Target as Object;

            return new DelegateInfo() { Target = target , Method = methodInfo };
        }

    #endregion
    }
}