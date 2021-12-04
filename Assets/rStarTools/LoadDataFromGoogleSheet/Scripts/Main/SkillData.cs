#region

using System;
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

    #region Private Methods

        [Button]
        [BoxGroup("LoadData")]
        private void ParseDataFromGoogleSheet()
        {
            GoogleSheetService.LoadDataArray<SkillInfo>(url , infos => skillInfos = infos);
        }

    #endregion
    }

    [Serializable]
    internal class SkillInfo
    {
    #region Public Variables

        public int    UUID;
        public string Accuracy;
        public string Description;
        public string Name;
        public string Power;
        public string PP;
        public string Type;

    #endregion
    }
}