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

        [PropertyOrder(1)]
        [TableColumnWidth(30 , false)]
        public int UUID;

        [PropertyOrder(5)]
        [TableColumnWidth(60 , false)]
        public string Accuracy;

        [PropertyOrder(7)]
        public string Description;

        [PropertyOrder(2)]
        [TableColumnWidth(100 , false)]
        public string Name;

        [PropertyOrder(4)]
        [TableColumnWidth(40 , false)]
        public string Power;

        [PropertyOrder(6)]
        [TableColumnWidth(40 , false)]
        public string PP;

        [PropertyOrder(3)]
        [TableColumnWidth(60 , false)]
        public string Type;

    #endregion
    }
}