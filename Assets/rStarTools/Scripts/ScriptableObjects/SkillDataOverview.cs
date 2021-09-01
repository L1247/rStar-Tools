using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SkillDataOverview" , menuName = "rStar/SkillDataOverview" , order = 0)]
    public class SkillDataOverview : DataOverviewBase<SkillDataOverview , SkillData> { }
}