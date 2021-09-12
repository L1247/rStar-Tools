#region

using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using rStarTools.Scripts.StringList;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

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

        [LabelText("賣出價格:")]
        [LabelWidth(55)]
        [FormerlySerializedAs("sellPrice")]
        public int SellPrice;

    #endregion
    }
}