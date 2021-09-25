#region

using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.StringList
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