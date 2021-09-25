#region

using System;
using rStarTools.Scripts.StringList;

#endregion

namespace Main.GameDataStructure
{
    [Serializable]
    public class ActorTypeName : NameBase<ActorTypeDataOverview>
    {
    #region Protected Variables

        protected override string LabelText => "角色類型：";

    #endregion
    }
}