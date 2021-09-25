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

        public bool ColorText = true;

        public bool  ShowIcon;
        public bool  UseLowSaturation;
        public float R = 1 , G = 1 , B = 1 , A = 1;

        public string Color;
        public string Icon;
        public int    MarginBottom { get; set; }
        public int    MarginTop    { get; set; }

    #endregion

    #region Constructor

        public ColoredBoxGroupAttribute(
            string group ,
            float  r , float g , float b , float a ,
            float  order = 0) : base(group , true , false , order)
        {
            R         = r;
            G         = g;
            B         = b;
            A         = a;
            ShowLabel = true;
        }

        public ColoredBoxGroupAttribute(
            string group ,
            float  order = 0) : base(group , true , false , order)
        {
            ShowLabel = true;
        }

    #endregion
    }
}