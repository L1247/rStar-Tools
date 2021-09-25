#region

using System;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.StringList
{
    [Serializable]
    public class DataBase<D> : IUniqueId where D : ScriptableObject , IDataOverview
    {
    #region Public Variables

        public string DataId      => uniqueId.DataId;
        public string DisplayName => uniqueId.DisplayName;

    #endregion

    #region Private Variables

        [HideLabel]
        [SerializeField]
        private UniqueId<D> uniqueId;

    #endregion

    #region Public Methods

        public void SetDataId(string id)
        {
            uniqueId.SetDataId(id);
        }

        public void SetDisplayName(string newDisplayName)
        {
            uniqueId.SetDisplayName(newDisplayName);
        }

    #endregion
    }
}