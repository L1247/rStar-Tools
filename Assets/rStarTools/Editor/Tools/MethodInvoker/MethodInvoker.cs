#region

using UnityEngine;
#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using UnityEditor;
#endif

#endregion

namespace rStarTools.MethodInvoker
{
    public class MethodInvoker : OdinEditorWindow
    {
    #region Public Variables

        [MenuItem("Tools/Method Invoker")]
        public static void ShowMenu()
        {
            instance = GetWindow<MethodInvoker>();
            instance.Show();
        }

        public MethodContainer container;

    #endregion

    #region Private Variables

        private static MethodInvoker instance;
        private        GameObject    target;

    #endregion
    }
}