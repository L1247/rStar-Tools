#region

using System;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;

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