#region

using System;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using rStarTools.Scripts.StringList;

#endregion

namespace ScriptableObjects.Names
{
    [Serializable]
    public class ActorName : NameBase<ActorDataOverview>
    {
    #region Protected Variables

        protected override string LabelText => "角色名稱:";

    #endregion
    }
}