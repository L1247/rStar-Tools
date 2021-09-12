#region

using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.Datas
{
    [CreateAssetMenu(fileName = "SkillData" , menuName = "rStar/SkillData")]
    public class SkillData : SODataBase<SkillDataOverview>
    {
    #region Private Variables

        [SerializeField]
        [LabelWidth(55)]
        [LabelText("技能威力:")]
        [ValidateInput("@skillPower > 0" , "技能威力不能小於0")]
        private int skillPower;

    #endregion
    }
}