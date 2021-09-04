using System;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using rStarTools.Scripts.ScriptableObjects.Datas;

namespace rStarTools.Scripts.ScriptableObjects.Names
{
    [Serializable]
    public class SkillName : NameBase<SkillDataOverview , SkillData>
    {
    #region Overrides of NameBase<SkillDataOverview,SkillData>

        protected override string            LabelText         => "技能名稱:";
        protected override SkillDataOverview GetDataOverview() => SkillDataOverview.Instance;

    #endregion
    }
}