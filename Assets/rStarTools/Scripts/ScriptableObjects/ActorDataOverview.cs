using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EditorUtilities;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ActorDataOverview" , menuName = "rStar/ActorDataOverview" , order = 0)]
    public class ActorDataOverview : SingletonScriptableObject<ActorDataOverview>
    {
        [ListDrawerSettings(HideAddButton = true , OnTitleBarGUI = "ActorDatasTitleBarGUI" , ShowItemCount = true)]
        [SerializeField]
        private List<ActorData> actorDatas = new List<ActorData>();

        public static IEnumerable SkillNames = new ValueDropdownList<string>()
        {
            { "1/122" , "3" } ,
            { "2/125" , "5" } ,
        };


        public static IEnumerable GetActorNames()
        {
            var valueDropdownItems = Instance
                                     .actorDatas
                                     .Select(data => new ValueDropdownItem
                                     {
                                         Text  = data.DisplayName ,
                                         Value = data.DataId ,
                                     });
            return valueDropdownItems;
        }

        public static bool IsStringContains(string value)
        {
            var actorData     = Instance.FindActorData(value);
            var valueContains = actorData != null;
            return valueContains;
        }


        private void ActorDatasTitleBarGUI()
        {
            if (GUILayout.Button("UpdateActorDatas"))
            {
                UpdateActorDatas();
            }
        }

        private void UpdateActorDatas()
        {
            actorDatas = CustomEditorUtility.GetScriptableObjects<ActorData>();
        }

        public ActorData FindActorData(string value)
        {
            var actorData = actorDatas.Find(data => data.DataId == value);
            return actorData;
        }
    }
}