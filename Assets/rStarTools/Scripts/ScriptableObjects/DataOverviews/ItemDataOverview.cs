#region

using rStarTools.Scripts.ScriptableObjects.Datas;
using rStarTools.Scripts.StringList;

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

    #region Protected Methods

        protected override bool ExtraCondition(ItemData data)
        {
            return data.Deactivate == false;
        }

        protected override string GetElementBoxText(int index)
        {
            var elementBoxText = base.GetElementBoxText(index);
            var itemData       = GetAllData()[index];
            var text           = $"{elementBoxText} - {itemData.DisplayName}";
            return text;
        }

    #endregion
    }
}