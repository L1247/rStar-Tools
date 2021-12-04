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

        public int UUID => uuid;

        public string Accuracy => accuracy;

        public string Description => description;

        public string Name => name;

        public string Power => power;

        public string PP => pp;

    #endregion

    #region Private Variables

        [PropertyOrder(1)]
        [TableColumnWidth(30 , false)]
        [SerializeField]
        private int uuid;

        [PropertyOrder(5)]
        [TableColumnWidth(60 , false)]
        [SerializeField]
        private string accuracy;

        [PropertyOrder(7)]
        [SerializeField]
        private string description;

        [PropertyOrder(2)]
        [TableColumnWidth(100 , false)]
        [SerializeField]
        private string name;

        [PropertyOrder(4)]
        [TableColumnWidth(40 , false)]
        [SerializeField]
        private string power;

        [PropertyOrder(6)]
        [TableColumnWidth(40 , false)]
        [SerializeField]
        private string pp;

        [PropertyOrder(3)]
        [TableColumnWidth(60 , false)]
        [SerializeField]
        private string type;

    #endregion
    }
}