#region

using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.Datas;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.DataOverviews
{
    public class ItemDataOverview : DataOverviewBase<ItemDataOverview , ItemData>
    {
    #region Public Methods

        public override bool Validate(string id)
        {
            var containId = base.Validate(id);
            if (containId == false) return false;
            var uniqueId = FindUniqueId(id);
            if (uniqueId.Deactivate) return false;
            return true;
        }

    #endregion
    }
}