#region

using System;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace LoadDataFromGoogleSheet
{
    [Serializable]
    public class SkillInfo : ISkillInfo
    {
    #region Public Variables

        public int UUID => uuid;

        public string Accuracy => accuracy;

        public string Description => description;

        public string Name => name;

        public string Power => power;

        public string PP => pp;

        public string Type => type;

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