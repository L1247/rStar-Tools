using System;
using UnityEngine;

namespace rStarTools.Scripts.Main.Custom_Attributes
{
    public class LabelWidthStringAttribute : Attribute
    {
        public string Width;
        public LabelWidthStringAttribute(string width) => Width = width;
    }
}