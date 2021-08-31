using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace rStarTools.Scripts.Main
{
    public class EnumScript : MonoBehaviour
    {
        [SerializeField]
        [InlineButton("ShowEnum")]
        [LabelWidth(80)]
        private CustomName customName;

        private void ShowEnum()
        {
            Debug.Log($"customName: {customName}");
        }
    }
}