#region

using System;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using rStarTools.Scripts.ScriptableObjects.Datas;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.Names
{
    [Serializable]
    public class ItemName : NameBase<ItemDataOverview , ItemData>
    {
    #region Protected Variables

        protected override string LabelText => "道具名稱:";

    #endregion

    #region Protected Methods

        protected override ItemDataOverview GetDataOverview()
        {
            return ItemDataOverview.Instance;
        }

    #endregion
    }
}