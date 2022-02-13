#region

using System.Reflection;
using UnityEngine;

#endregion

namespace rStarTools.MethodInvoker
{
    public struct DelegateInfo
    {
        public Object     Target;
        public MethodInfo Method;
    }
}