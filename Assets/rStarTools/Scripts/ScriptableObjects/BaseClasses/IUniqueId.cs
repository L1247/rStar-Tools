namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public interface IUniqueId
    {
    #region Public Variables

        public string DataId      { get; }
        public string DisplayName { get; }

    #endregion

    #region Public Methods

        public void SetErrorMessage(string message);

    #endregion
    }
}