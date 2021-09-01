using System;
using System.Collections;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using ScriptableObjects;

namespace rStarTools.Scripts.ScriptableObjects.Names
{
    [Serializable]
    public class SkillName : NameBase
    {
        protected override IEnumerable GetNames()               => SkillDataOverview.Instance.GetNames();
        protected override bool        ValidateId(string value) => SkillDataOverview.Instance.IsStringContains(value);
    }
}