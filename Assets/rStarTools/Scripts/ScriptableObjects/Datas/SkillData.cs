#region

using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.Datas
{
    [CreateAssetMenu(fileName = "SkillData" , menuName = "rStar/SkillData" , order = 0)]
    public class SkillData : SODataBase<SkillDataOverview> { }
}