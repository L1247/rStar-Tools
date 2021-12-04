using UnityEditor;
using UnityEngine;

namespace Zenject.MemoryPoolMonitor
{
    public class MpmWindow : ZenjectEditorWindow
    {
    #region Public Variables

        [MenuItem("Window/Zenject Pool Monitor")]
        public static MpmWindow GetOrCreateWindow()
        {
            var window = EditorWindow.GetWindow<MpmWindow>();
            window.titleContent = new GUIContent("Pool Monitor");
            return window;
        }

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            MpmSettingsInstaller.InstallFromResource(Container);

            Container.BindInstance(this);
            Container.BindInterfacesTo<MpmView>().AsSingle();
        }

    #endregion
    }
}