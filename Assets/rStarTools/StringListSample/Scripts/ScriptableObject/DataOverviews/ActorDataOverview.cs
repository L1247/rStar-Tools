#region

using rStarTools.Scripts.ScriptableObjects.Datas;
using rStarTools.Scripts.StringList;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.DataOverviews
{
    public class ActorDataOverview : DataOverviewBase<ActorDataOverview , ActorData>
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

        protected override bool ExtraCondition(ActorData data)
        {
            return data.Deactivate == false;
        }

    #endregion
    }
}