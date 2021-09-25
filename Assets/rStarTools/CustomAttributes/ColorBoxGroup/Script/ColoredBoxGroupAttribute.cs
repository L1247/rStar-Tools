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

        public bool  ShowIcon;
        public float R , G , B , A;

        public string Color;
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
            string color ,
            float  order = 0) : base(group , true , false , order)
        {
            Color     = color;
            ShowLabel = true;
        }

    #endregion
    }
}