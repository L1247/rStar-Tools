#region

using System;
using Sirenix.OdinInspector;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Serializable]
    public class UniqueId
    {
    #region Public Variables

        [ReadOnly]
        public string DataId;

        public string DisplayName;

    #endregion

    #region Constructor

        public UniqueId()
        {
            DataId = Guid.NewGuid().ToString();
        }

    #endregion
    }
}