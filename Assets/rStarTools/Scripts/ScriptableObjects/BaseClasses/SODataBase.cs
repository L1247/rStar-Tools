using Sirenix.OdinInspector;
using UnityEngine;

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public class SODataBase : ScriptableObject
    {
    #region Public Variables

        public virtual string DataId      => uniqueId.DataId;
        public virtual string DisplayName => uniqueId.DisplayName;

    #endregion

    #region Private Variables

        [SerializeField]
        [HideLabel]
        private UniqueId uniqueId;

    #endregion
    }
}