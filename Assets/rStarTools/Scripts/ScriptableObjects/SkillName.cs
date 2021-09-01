using System;
using System.Collections;

namespace ScriptableObjects
{
    [Serializable]
    public class SkillName : NameBase
    {
        protected override IEnumerable GetNames()               => SkillDataOverview.Instance.GetNames();
        protected override bool        ValidateId(string value) => SkillDataOverview.Instance.IsStringContains(value);
    }
}