#region

using System.Collections;
using System.Collections.Generic;

#endregion

namespace rStarTools.Scripts.StringList
{
    public interface IDataOverview
    {
    #region Public Methods

        public string          GetDataPath();
        bool                   ContainsId(string id);
        public List<IUniqueId> GetAllUniqueId();
        int                    FindIndex(string       id);
        IUniqueId              GetUniqueIdByIndex(int index);
        IEnumerable            GetNames();
        bool                   Validate(string    id);
        bool                   ValidateAll(string id);

    #endregion
    }
}