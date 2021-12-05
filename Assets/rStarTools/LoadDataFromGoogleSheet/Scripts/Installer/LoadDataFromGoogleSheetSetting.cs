#region

using UnityEngine;
using Zenject;

#endregion

namespace LoadDataFromGoogleSheet.Scripts.Installer
{
    public class LoadDataFromGoogleSheetSetting : ScriptableObjectInstaller
    {
    #region Private Variables

        [SerializeField]
        private SkillData skillData;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(skillData).AsSingle();
        }

    #endregion
    }
}