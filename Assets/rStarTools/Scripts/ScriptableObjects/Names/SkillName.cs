#region

using System;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.Names
{
    [Serializable]
    public class SkillName : NameBase<SkillDataOverview>
    {
    #region Protected Variables

        protected override string LabelText => "技能名稱:";

    #endregion
    }
}