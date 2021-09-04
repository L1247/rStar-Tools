using System;
using System.Collections;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using rStarTools.Scripts.ScriptableObjects.Datas;
using ScriptableObjects;

namespace rStarTools.Scripts.ScriptableObjects.Names
{
    [Serializable]
    public class SkillName : NameBase<SkillDataOverview , SkillData>
    {
        protected override string LabelText => "技能名稱";
        protected override SkillDataOverview GetDataOverview() => SkillDataOverview.Instance;
    }
}