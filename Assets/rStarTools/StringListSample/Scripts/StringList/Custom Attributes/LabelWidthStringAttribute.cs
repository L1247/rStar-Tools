#region

using System;

#endregion

namespace rStarTools.Scripts.StringList.Custom_Attributes
{
    public class LabelWidthStringAttribute : Attribute
    {
    #region Public Variables

        public string Width;

    #endregion

    #region Constructor

        public LabelWidthStringAttribute(string width)
        {
            Width = width;
        }

    #endregion
    }
}