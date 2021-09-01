using System;
using System.Collections;

namespace ScriptableObjects
{
    [Serializable]
    public class SkillName : NameBase
    {
        protected override IEnumerable GetNames()
        {
            return SkillDataOverview.Instance.GetNames();
        }

        protected override bool ValidateId(string value)
        {
            return SkillDataOverview.Instance.IsStringContains(value);
        }
    }
}