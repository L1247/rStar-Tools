#region

using System;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.Names
{
    [Serializable]
    public class ItemName : NameBase<ItemDataOverview>
    {
    #region Protected Variables

        protected override int overviewWidth => 600;

        protected override string LabelText => "道具名稱:";

    #endregion
    }
}