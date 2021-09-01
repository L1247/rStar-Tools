using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EditorUtilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects
{
    public class DataOverviewBase<T , D> : SingletonScriptableObject<T> where D : SODataBase where T : ScriptableObject
    {
        [ListDrawerSettings(HideAddButton = true , OnTitleBarGUI = "DatasTitleBarGUI" , ShowItemCount = true)]
        [SerializeField]
        public List<D> datas = new List<D>();

        private void DatasTitleBarGUI()
        {
            if (GUILayout.Button("UpdateDatas")) UpdateDatas();
        }

        protected virtual void UpdateDatas() => datas = CustomEditorUtility.GetScriptableObjects<D>();

        public virtual D FindData<D>(string value) where D : class
        {
            var data = datas.Find(data => data.DataId == value) as D;
            return data;
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

        public virtual bool IsStringContains(string value)
        {
            var data          = FindData<D>(value);
            var valueContains = data != null;
            return valueContains;
        }
    }
}