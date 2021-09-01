using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.Datas;
using UnityEngine;

namespace rStarTools.Scripts.ScriptableObjects.DataOverviews
{
    [CreateAssetMenu(fileName = "SkillDataOverview" , menuName = "rStar/SkillDataOverview" , order = 0)]
    public class SkillDataOverview : DataOverviewBase<SkillDataOverview , SkillData> { }
}