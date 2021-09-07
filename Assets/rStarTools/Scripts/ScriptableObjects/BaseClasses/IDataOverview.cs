#region

using System.Collections;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public interface IDataOverview
    {
    #region Public Methods

        IEnumerable GetNames();
        bool        Validate(string id);

        bool ValidateAll(string id);

    #endregion
    }
}