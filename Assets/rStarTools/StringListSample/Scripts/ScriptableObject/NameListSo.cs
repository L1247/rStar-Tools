#region

using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NameListSo" , menuName = "rStar/NameListSo" , order = 0)]
    public class NameListSo : ScriptableObject
    {
    #region Public Variables

        public static IEnumerable SkillNames = new ValueDropdownList<string>()
        {
            { "1/122" , "3" } ,
            { "2/125" , "5" }
        };

        public static string[] SkillNameArray = { "4" , "5" };

    #endregion

    #region Private Variables

        [SerializeField]
        private List<string> skillName;

    #endregion
    }
}