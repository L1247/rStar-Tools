#region

using System.Collections;
using System.Collections.Generic;

#endregion

namespace rStarTools.Scripts.StringList
{
    public interface IDataOverview
    {
    #region Public Methods

        void AddData(IUniqueId uniqueId);

        bool                   ContainsId(string id);
        int                    FindIndex(string  id);
        public List<IUniqueId> GetAllUniqueId();

        public string GetDataPath();
        IEnumerable   GetNames();
        IUniqueId     GetUniqueIdByIndex(int index);
        bool          Validate(string        id);

    #endregion
    }
}