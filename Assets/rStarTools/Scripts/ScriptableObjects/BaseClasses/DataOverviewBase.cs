#region

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EditorUtilities;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public class DataOverviewBase<T , D> : SingletonScriptableObject<T> where D : SODataBase where T : ScriptableObject
    {
    #region Protected Variables

        [ListDrawerSettings(HideAddButton = true , OnTitleBarGUI = "DatasTitleBarGUI" , ShowItemCount = true)]
        [SerializeField]
        protected List<D> datas = new List<D>();

    #endregion

    #region Public Methods

        public virtual D FindData<D>(string value) where D : class
        {
            var data = datas.Find(data => data.DataId == value) as D;
            return data;
        }

        public List<D> GetAllData()
        {
            return datas;
        }

        public virtual void AddNewData(D newData)
        {
            datas.Add(newData);
            CustomEditorUtility.SetDirty(this);
            CustomEditorUtility.SaveAssets();
        }

        public virtual IEnumerable GetNames()
        {
            var valueDropdownItems = datas
                .Select(data => new ValueDropdownItem
                {
                    Text  = data.DisplayName ,
                    Value = data.DataId ,
                });
            return valueDropdownItems;
        }

        public virtual bool Validate(string value)
        {
            var data          = FindData<D>(value);
            var valueContains = data != null;
            return valueContains;
        }

    #endregion

    #region Protected Methods

        protected virtual void UpdateDatas()
        {
            datas = CustomEditorUtility.GetScriptableObjects<D>();
            CustomEditorUtility.SetDirty(this);
            CustomEditorUtility.SaveAssets();
        }

    #endregion

    #region Private Methods

        private void DatasTitleBarGUI()
        {
            if (GUILayout.Button("UpdateDatas")) UpdateDatas();
        }

    #endregion
    }
}