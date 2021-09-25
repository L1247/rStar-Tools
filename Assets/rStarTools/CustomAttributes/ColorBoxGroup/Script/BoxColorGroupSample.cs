#region

using rStarTools.Scripts.StringList.Custom_Attributes;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.CustomAttributes
{
    public class BoxColorGroupSample : MonoBehaviour
    {
    #region Public Variables

        [ShowInInspector]
        [ColoredBoxGroup("Box1")]
        public Texture2D iconForBox1 => EditorIcons.Tag.Raw;

        [ColoredBoxGroup("Box2")]
        public Color group2Color = Color.green;

        [ColoredBoxGroup(                                    "Box1" ,            R = .43f , G = .96f , B = .64f ,
                                           ShowIcon = true , ColorText = false , Icon = "@iconForBox1")]
        [PropertyOrder(-1)]
        public string A;

        [ColoredBoxGroup("Box1")]
        public string B;

        [ColoredBoxGroup("Box2" , Color = "@group2Color" , ShowIcon = true , ColorText = true ,
                         Icon = "@iconForBox2")]
        [PropertyOrder(-1)]
        public string C;

        [PreviewField]
        [ColoredBoxGroup("Box2")]
        public Texture2D iconForBox2;

    #endregion
    }
}