#region

using rStarTools.Scripts.ScriptableObjects.Names;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.Main
{
    public class Item : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        [LabelText("新名字:")]
        // [HideLabel]
        private ItemName itemName;

    #endregion
    }
}