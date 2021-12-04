namespace LoadDataFromGoogleSheet
{
    internal interface ISkillInfo
    {
    #region Public Variables

        int    UUID        { get; }
        string Accuracy    { get; }
        string Description { get; }
        string Name        { get; }
        string Power       { get; }
        string PP          { get; }

    #endregion
    }
}