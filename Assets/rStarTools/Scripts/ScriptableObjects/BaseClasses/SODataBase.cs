#region

using Sirenix.OdinInspector;
using UnityEngine;

#endregion

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
        [BoxGroup]
        private UniqueId uniqueId;

    #endregion
    }
}