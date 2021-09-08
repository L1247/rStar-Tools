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

        [LabelText("是否棄用")]
        public bool Deactivate;

    #endregion

    #region Private Variables

        [SerializeField]
        [BoxGroup("ItemData")]
        private int sellPrice;

    #endregion
    }
}