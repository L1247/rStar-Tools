#region

using System.Collections;
using System.Linq;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.Datas;
using Sirenix.OdinInspector;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.DataOverviews
{
    public class ItemDataOverview : DataOverviewBase<ItemDataOverview , ItemData>
    {
    #region Public Methods

        public override IEnumerable GetNames()
        {
            var valueDropdownItems = datas
                                     .Where(data => data.Deactivate == false)
                                     .Select(data => new ValueDropdownItem
                                     {
                                         Text  = data.DisplayName ,
                                         Value = data.DataId
                                     });
            return valueDropdownItems;
        }

        public override bool Validate(string value)
        {
            var data          = FindData<ItemData>(value);
            var dataNotNull   = data != null;
            var activate      = data.Deactivate == false;
            var valueContains = dataNotNull && activate;
            return valueContains;
        }

    #endregion
    }
}