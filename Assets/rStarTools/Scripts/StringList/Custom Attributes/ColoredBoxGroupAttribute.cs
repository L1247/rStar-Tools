#region

using System;
using Sirenix.OdinInspector;

#endregion

namespace rStarTools.Scripts.StringList.Custom_Attributes
{
    [AttributeUsage(AttributeTargets.All , AllowMultiple = true)]
    public class ColoredBoxGroupAttribute : BoxGroupAttribute
    {
    #region Public Variables

        public bool   BoldLabel;
        public float  R , G , B , A;
        public string LabelText;
        public bool   ShowIcon     { get; set; }
        public int    MarginBottom { get; set; }
        public int    MarginTop    { get; set; }

    #endregion

    #region Constructor

        public ColoredBoxGroupAttribute(
            string group ,
            float  r , float g , float b , float a ,
            bool   showLabel   = true ,
            bool   centerLabel = false ,
            bool   boldLabel   = false ,
            float  order       = 0 , bool showIcon = false) : base(group , showLabel , centerLabel , order)
        {
            ShowIcon = showIcon;
            R        = r;
            G        = g;
            B        = b;
            A        = a;

            BoldLabel = boldLabel;
        }

        public ColoredBoxGroupAttribute(
            string group ,
            string label ,
            float  r , float g , float b , float a ,
            bool   showLabel   = true ,
            bool   centerLabel = false ,
            bool   boldLabel   = false ,
            float  order       = 0 , bool showIcon = false) : base(group , showLabel , centerLabel , order)
        {
            ShowIcon = showIcon;
            R        = r;
            G        = g;
            B        = b;
            A        = a;

            LabelText = label;
            BoldLabel = boldLabel;
        }

    #endregion
    }
}