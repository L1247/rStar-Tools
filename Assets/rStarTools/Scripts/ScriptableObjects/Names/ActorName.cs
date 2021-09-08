#region

using System;
using System.Collections;
using System.Linq;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using Sirenix.OdinInspector;

#endregion

namespace ScriptableObjects.Names
{
    [Serializable]
    public class ActorName : NameBase<ActorDataOverview>
    {
    #region Protected Variables

        protected override string LabelText => "角色名稱:";

    #endregion

    #region Protected Methods

        protected override IEnumerable GetNames()
        {
            var actorDatas = GetDataOverview().GetAllData();
            var valueDropdownItems = actorDatas
                                     .Where(data => data.Deactivate == false)
                                     .Select(data => new ValueDropdownItem
                                     {
                                         Text  = data.DisplayName ,
                                         Value = data.DataId ,
                                     });
            return valueDropdownItems;
        }

    #endregion
    }
}