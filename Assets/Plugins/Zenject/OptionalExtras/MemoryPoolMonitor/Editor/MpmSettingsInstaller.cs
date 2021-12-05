using UnityEditor;
using UnityEngine;

namespace Zenject.MemoryPoolMonitor
{
    [CreateAssetMenu(fileName = "MpmSettingsInstaller" , menuName = "Installers/MpmSettingsInstaller")]
    public class MpmSettingsInstaller : ScriptableObjectInstaller<MpmSettingsInstaller>
    {
    #region Public Variables

        public MpmView.Settings MpmView;
        public MpmView.Settings MpmViewDark;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(EditorGUIUtility.isProSkin ? MpmViewDark : MpmView);
        }

    #endregion
    }
}