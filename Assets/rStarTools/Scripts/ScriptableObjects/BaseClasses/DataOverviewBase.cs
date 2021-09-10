#region

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using Sirenix.Utilities.Editor;
#endif

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Searchable]
    public class DataOverviewBase<DO , U> : SingletonScriptableObject<DO> , IDataOverview
    where DO : ScriptableObject , IDataOverview
    where U : IUniqueId
    {
    #region Protected Variables

        [SerializeField]
        [LabelText("資料陣列")]
        [TableList(ShowIndexLabels = true)]
        [Searchable]
        [ListDrawerSettings(OnBeginListElementGUI = "BeginListElementGUI" , OnEndListElementGUI = "EndListElementGUI")]
        protected List<U> ids = new List<U>();

    #endregion

    #region Public Methods

        public D FindData<D>(string id) where D : UniqueId<DO>
        {
            var data = GetAllData().Find(_ => _.DataId == id) as D;
            return data;
        }

        public U FindUniqueId(string id)
        {
            return ids.Find(uniqueId => uniqueId.DataId == id);
        }

        public List<U> GetAllData()
        {
            return ids;
        }

        public virtual IEnumerable GetNames()
        {
            var valueDropdownItems = ids
                                     .Where(id => string.IsNullOrEmpty(id.DisplayName) == false)
                                     .Where(data => ExtraCondition(data))
                                     .Select(element => new ValueDropdownItem
                                     {
                                         Text  = element.DisplayName ,
                                         Value = element.DataId
                                     });
            return valueDropdownItems;
        }

        public virtual bool Validate(string id)
        {
            var containsId = FindUniqueId(id) != null;
            return containsId;
        }

        public bool ValidateAll(string id)
        {
            var uniqueId    = FindUniqueId(id);
            var displayName = uniqueId.DisplayName;
            if (string.IsNullOrEmpty(displayName))
            {
                uniqueId.SetErrorMessage("顯示名稱不能為空");
                return false;
            }

            var isDisplayNameSame = ids.FindAll(_ => _.DisplayName == displayName).Count < 2;
            if (isDisplayNameSame == false) uniqueId.SetErrorMessage($"檢查到有相同顯示名稱: {displayName}");
            return isDisplayNameSame;
        }

    #endregion

    #region Protected Methods

        protected virtual bool ExtraCondition(U data)
        {
            return true;
        }

        protected virtual string GetElementBoxText(int index)
        {
            var text = $"Index: {index}";
            return text;
        }

    #endregion

    #if UNITY_EDITOR
        [UsedImplicitly]
        private void BeginListElementGUI(int index)
        {
            GUILayout.BeginHorizontal();
            SirenixEditorGUI.BeginBox(GetElementBoxText(index));
        }


        [UsedImplicitly]
        private void EndListElementGUI(int index)
        {
            SirenixEditorGUI.EndBox();
            GUILayout.EndHorizontal();
        }
    #endif
    }
}