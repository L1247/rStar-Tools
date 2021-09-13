namespace rStarTools.Scripts.StringList
{
    public interface IUniqueId
    {
    #region Public Variables

        public string DataId      { get; }
        public string DisplayName { get; }

    #endregion

    #region Public Methods

        public void SetDataId(string      id);
        public void SetDisplayName(string newDisplayName);

    #endregion
    }
}