#region

using System.Collections;
using System.Collections.Generic;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public interface IDataOverview
    {
    #region Public Methods

        bool ContainsId(string id);

        int FindIndex(string id);

        public List<IUniqueId> GetAllData();
        IUniqueId              GetData(int index);
        IEnumerable            GetNames();
        bool                   Validate(string    id);
        bool                   ValidateAll(string id);

    #endregion
    }
}