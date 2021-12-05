#region

using System.Collections.Generic;
using AutoBot.Utilities;
using UniRx;
using Zenject;

#endregion

namespace LoadDataFromGoogleSheet.Scripts.Presenter
{
    public class DemoPresenter : IInitializable
    {
    #region Private Variables

        [Inject]
        private SkillData skillData;

        [Inject]
        private PanelSkill panelSkill;

        private List<SkillInfo> skillInfos;

    #endregion

    #region Public Methods

        public void Initialize()
        {
            skillInfos = skillData.GetAllSkillInfo();
            var buttonRandomSKill = panelSkill.buttonRandomSKill;
            buttonRandomSKill.OnClickAsObservable()
                             .Subscribe(_ => RandomSkill())
                             .AddTo(buttonRandomSKill);
            RandomSkill();
        }

    #endregion

    #region Private Methods

        private void RandomSkill()
        {
            var skillInfo   = RandomUtilities.GetRandomData(skillInfos);
            var uuid        = skillInfo.UUID;
            var name        = skillInfo.Name;
            var type        = skillInfo.Type;
            var power       = skillInfo.Power;
            var accuracy    = skillInfo.Accuracy;
            var pp          = skillInfo.PP;
            var description = skillInfo.Description;
            panelSkill.UpdatePanel(uuid , name , type , power , accuracy ,
                                   pp , description);
        }

    #endregion
    }
}