#region

using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace rStarTools.MethodInvoker
{
    [Serializable]
    public class MethodEntry : ISerializationCallbackReceiver
    {
    #region Public Variables

        [NonSerialized]
        [HideInInspector]
        public Delegate Delegate;

        [NonSerialized]
        [HideInInspector]
        public object[] ParameterValues;

    #endregion

    #region Private Variables

        [SerializeField]
        [HideInInspector]
        private List<Object> unityReferences;

        [SerializeField]
        [HideInInspector]
        private byte[] bytes;

    #endregion

    #region Constructor

        public MethodEntry(Delegate del)
        {
            if (del != null && del.Method != null)
            {
                Delegate        = del;
                ParameterValues = new object[del.Method.GetParameters().Length];
            }
        }

    #endregion

    #region Public Methods

        public void Invoke()
        {
            if (Delegate != null && ParameterValues != null)
                // This is faster than Dynamic Invoke.
                /*this.Result = */
                Delegate.Method.Invoke(Delegate.Target , ParameterValues);
        }

        public void OnAfterDeserialize()
        {
            var val = SerializationUtility.DeserializeValue<OdinSerializedData>(bytes , DataFormat.Binary , unityReferences);
            Delegate        = val.Delegate;
            ParameterValues = val.ParameterValues;
        }

        public void OnBeforeSerialize()
        {
            var val = new OdinSerializedData() { Delegate = Delegate , ParameterValues = ParameterValues };
            bytes = SerializationUtility.SerializeValue(val , DataFormat.Binary , out unityReferences);
        }

    #endregion

    #region Nested Types

        private struct OdinSerializedData
        {
            public Delegate Delegate;
            public object[] ParameterValues;
        }

    #endregion
    }
}