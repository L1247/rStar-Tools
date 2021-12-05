#region

using LoadDataFromGoogleSheet.Scripts.Presenter;
using Zenject;

#endregion

namespace LoadDataFromGoogleSheet.Scripts.Installer
{
    public class LoadDataFromGoogleSheetInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DemoPresenter>().AsSingle();
        }

    #endregion
    }
}