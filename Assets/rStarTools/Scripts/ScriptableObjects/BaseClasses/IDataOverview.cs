#region

using System.Collections;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public interface IDataOverview
    {
    #region Public Methods

        bool ContainsId(string id);

        IEnumerable GetNames();
        void        SetTarget(string   id);
        bool        Validate(string    id);
        bool        ValidateAll(string id);

    #endregion
    }
}