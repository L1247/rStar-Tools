using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NameListSo" , menuName = "rStar/NameListSo" , order = 0)]
    public class NameListSo : ScriptableObject
    {
        [SerializeField]
        private List<string> SkillName;

        public static string[] SkillNameArray = new string[] { "4" , "5" };
        public static IEnumerable SkillNames = new ValueDropdownList<string>()
        {
            { "1/122" , "3" } ,
            { "2/125" , "5" },
        };
    }
}