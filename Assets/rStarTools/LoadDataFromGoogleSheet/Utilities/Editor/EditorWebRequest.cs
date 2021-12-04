#region

using System;
using UnityEngine;
using UnityEngine.Networking;

#endregion

namespace rStar.Tools.Editor
{
    public class EditorWebRequest
    {
    #region Public Variables

        public static event Action<string> Complete;

        public static void ClearAction()
        {
            Complete = null;
        }

        /// <summary>
        ///     get json Text
        /// </summary>
        /// <param name="url"></param>
        /// <returns>jsonText</returns>
        public static void Request(string url)
        {
            www                            =  UnityWebRequest.Get(url);
            www.SendWebRequest().completed += RequestComplete;
        }

    #endregion

    #region Private Variables

        private static UnityWebRequest www;

    #endregion

    #region Private Methods

        private static void RequestComplete(AsyncOperation operation)
        {
            var jsonText = string.Empty;
            if (www.result == UnityWebRequest.Result.ConnectionError) Debug.Log(www.error);
            else jsonText = www.downloadHandler.text;

            Complete?.Invoke(jsonText);
            ClearAction();

            operation.completed -= RequestComplete;
        }

    #endregion
    }
}