#region

using rStarTools.Scripts.StringList.Custom_Attributes;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.CustomAttributes
{
    public class BoxColorGroupSample : MonoBehaviour
    {
    #region Public Variables

        [ColoredBoxGroup("Box2" , "@group2Color")]
        public Color group2Color = Color.green;

        [ColoredBoxGroup("Box1" , .43f , .96f , .64f , 1f ,
                         ShowIcon = true)]
        public string A;

        [ColoredBoxGroup("Box1" , .43f , .96f , .64f , 1f)]
        public string B;


        [ColoredBoxGroup("Box2" , "@group2Color" , ShowIcon = true)]
        public string C;

    #endregion
    }
}