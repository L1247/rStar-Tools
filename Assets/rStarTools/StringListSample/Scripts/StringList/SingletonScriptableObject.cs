#region

using EditorUtilities;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.StringList
{
    public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
    #region Public Variables

        public static T Instance
        {
            get
            {
                if (instance == null) instance = CustomEditorUtility.GetScriptableObject<T>();
                return instance;
            }
        }

    #endregion

    #region Private Variables

        private static T instance;

    #endregion
    }
}