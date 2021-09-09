#region

using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.Datas
{
    public class ItemData : SODataBase<ItemDataOverview>
    {
    #region Public Variables

        [LabelText("是否棄用:")]
        [LabelWidth(55)]
        [PropertyOrder(-1)]
        [TableColumnWidth(5)]
        public bool Deactivate;

    #endregion

    #region Private Variables

        [SerializeField]
        private int sellPrice;

    #endregion
    }
}