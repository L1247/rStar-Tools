#region

using UnityEngine;
#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using UnityEditor;
#endif

#endregion

namespace rStarTools.MethodInvoker
{
    public class MethodInvokerWindow : OdinEditorWindow
    {
    #region Public Variables

        [MenuItem("Tools/Method Invoker")]
        public static void ShowMenu()
        {
            instance = GetWindow<MethodInvokerWindow>();
            instance.Show();
        }

        public MethodContainer container;

    #endregion

    #region Private Variables

        private static MethodInvokerWindow instance;
        private        GameObject          target;

    #endregion

    #region Protected Methods

        protected override void OnEnable()
        {
            instance = GetWindow<MethodInvokerWindow>();
            EditorApplication.playModeStateChanged += change =>
            {
                if (change == PlayModeStateChange.EnteredEditMode)
                {
                    container.RefreshEntries();
                    Repaint();
                }
            };
        }

    #endregion
    }
}