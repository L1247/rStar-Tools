#region

using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.Main
{
    public class EnumScript : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        [InlineButton("ShowEnum")]
        [LabelWidth(80)]
        private CustomName customName;

    #endregion

    #region Private Methods

        private void ShowEnum()
        {
            Debug.Log($"customName: {customName}");
        }

    #endregion
    }
}