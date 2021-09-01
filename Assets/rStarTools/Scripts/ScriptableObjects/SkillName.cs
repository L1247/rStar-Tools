using System.Collections;

namespace ScriptableObjects
{
    public class SkillName : NameBase
    {
        protected override IEnumerable GetNames()
        {
            yield break;
        }

        protected override bool ValidateId(string value)
        {
            return false;
        }
    }
}