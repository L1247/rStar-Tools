#region

using System;
using ThirdParty.Utilities;
#if UNITY_EDITOR
using rStar.Tools.Editor;
#endif

#endregion

namespace Utilities
{
    public static class GoogleSheetService
    {
    #region Public Variables

        public static void LoadDataArray<T>(string url , Action<T[]> complete)
        {
        #if UNITY_EDITOR
            EditorWebRequest.Complete += delegate(string jsonText)
            {
                try
                {
                    var result = JsonHelper.FromJson<T>(jsonText , true);
                    complete.Invoke(result);
                }
                catch (Exception)
                {
                    EditorWebRequest.ClearAction();
                    throw;
                }
            };
            EditorWebRequest.Request(url);
        #endif
        }

    #endregion
    }
}