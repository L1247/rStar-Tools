using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SkillDataOverview" , menuName = "rStar/SkillDataOverview" , order = 0)]
    public class SkillDataOverview : SingletonScriptableObject<SkillDataOverview>
    {
        [ListDrawerSettings(HideAddButton = true , OnTitleBarGUI = "ActorDatasTitleBarGUI" , ShowItemCount = true)]
        [SerializeField]
        private List<SkillData> actorDatas = new List<SkillData>();
    }
}