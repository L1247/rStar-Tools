#region

using rStarTools.Scripts.StringList.Custom_Attributes;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.CustomAttributes
{
    public class BoxColorGroupSample : MonoBehaviour
    {
    #region Public Variables

        [ColoredBoxGroup(                                      "Box" , .43f , .96f , .64f , 1f ,
                                            BoldLabel = true , ShowIcon = true)]
        public string A;

        [ColoredBoxGroup(                                      "Box" , .43f , .96f , .64f , 1f ,
                                            BoldLabel = true , ShowIcon = true)]
        public string B;

    #endregion
    }
}