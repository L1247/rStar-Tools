#region

using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public class SODataBase<D> : ScriptableObject , IUniqueId where D : ScriptableObject , IDataOverview
    {
    #region Public Variables

        public string DataId      => uniqueId.DataId;
        public string DisplayName => uniqueId.DisplayName;

    #endregion

    #region Private Variables

        [SerializeField]
        [HideLabel]
        [BoxGroup]
        private UniqueId<D> uniqueId;

    #endregion

    #region Public Methods

        public void SetErrorMessage(string message)
        {
            uniqueId.SetErrorMessage(message);
        }

    #endregion
    }
}