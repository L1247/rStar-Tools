#region

using System;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;

#endregion

namespace Main.GameDataStructure
{
    [Serializable]
    public class ActorTypeNames : NameBase2<ActorTypeOverview>
    {
    #region Protected Variables

        protected override string LabelText => "角色類型：";

    #endregion
    }
}