#region

using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

#endregion

namespace LoadDataFromGoogleSheet
{
    public class SkillData : ScriptableObject
    {
    #region Private Variables

        [SerializeField]
        [LabelWidth(30)]
        [LabelText("Url:")]
        [BoxGroup("LoadData")]
        private string url = "https://opensheet.vercel.app/1Ps7_MYYRiIKxwqS3pkpwE4owEVOrybrHMsuY7RW6svI/Skill";

        [SerializeField]
        [TableList]
        private SkillInfo[] skillInfos;

    #endregion

    #region Public Methods

        public List<SkillInfo> GetAllSkillInfo()
        {
            return skillInfos.ToList();
        }

    #endregion

    #region Private Methods

        [Button]
        [BoxGroup("LoadData")]
        private void ParseDataFromGoogleSheet()
        {
            GoogleSheetService.LoadDataArray<SkillInfo>(url , infos => skillInfos = infos);
        }

    #endregion
    }
}