#region

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EditorUtilities;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using Sirenix.Utilities.Editor;
#endif

#endregion

namespace rStarTools.Scripts.StringList
{
    [Searchable]
    public class DataOverviewBase<DO , U> : SingletonScriptableObject<DO> , IDataOverview
    where DO : ScriptableObject , IDataOverview
    where U : class , IUniqueId
    {
    #region Protected Variables

        [SerializeField]
        [LabelText("@StringListDescription.DataList")]
        [TableList(ShowIndexLabels = true)]
        [Searchable]
        [ListDrawerSettings(OnBeginListElementGUI = "BeginListElementGUI" , OnEndListElementGUI = "EndListElementGUI" ,
                            Expanded = true)]
        protected List<U> ids = new List<U>();

    #endregion

    #region Private Variables

        [SerializeField]
        [UsedImplicitly]
        [LabelWidth(90)]
        [BoxGroup("DataPath")]
        [PropertyOrder(-2)]
        [ShowIf("IsDataScriptableObject")]
        private bool useDataPath;

        [SerializeField]
        [FolderPath]
        [LabelWidth(90)]
        [BoxGroup("DataPath")]
        [ShowIf("@useDataPath")]
        private string dataPath;

        [SerializeField]
        [LabelText("是否按DisplayName字母排序")]
        [LabelWidth(200)]
        [PropertyOrder(-5)]
        private bool sortingByDisplayName;

    #endregion

    #region Public Methods

        public void AddData(IUniqueId uniqueId)
        {
            var data = uniqueId as U;
            AddNewData(data);
        }

        public void AddNewData(U data)
        {
            ids.Add(data);
            SetThisDirty();
        }

        public bool ContainDisplayName(string displayName)
        {
            var uniqueId = FindDataByDisplayName(displayName);
            return uniqueId != null;
        }

        public bool ContainsId(string id)
        {
            var containsId = FindUniqueId(id) != null;
            return containsId;
        }

        public D FindData<D>(string id) where D : class , IUniqueId
        {
            var data = GetAllUniqueId().Find(_ => _.DataId == id) as D;
            return data;
        }

        public int FindIndex(string id)
        {
            var index = -1;
            for (var i = 0 ; i < ids.Count ; i++)
            {
                var uniqueId = ids[i];
                var idEquals = uniqueId.DataId == id;
                if (idEquals)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public U FindUniqueId(string id)
        {
            return ids.Find(uniqueId => uniqueId.DataId == id);
        }

        public List<U> GetAllData()
        {
            return ids;
        }

        public List<IUniqueId> GetAllUniqueId()
        {
            return ids.Cast<IUniqueId>().ToList();
        }

        public string GetDataPath()
        {
            return dataPath;
        }

        /// <summary>
        ///     if uniqueId is null , return empty.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDisplayName(string id)
        {
            var uniqueId = FindUniqueId(id);
            if (uniqueId == null) return string.Empty;
            return uniqueId.DisplayName;
        }


        public virtual IEnumerable GetNames()
        {
            var list = ids;
            if (sortingByDisplayName)
            {
                list = ids.ToList();
                list.Sort((x , y) => string.CompareOrdinal(x.DisplayName , y.DisplayName));
            }

            var valueDropdownItems = list
                                     .Where(id => id != null)
                                     .Where(id => string.IsNullOrEmpty(id.DisplayName) == false)
                                     .Where(ExtraCondition)
                                     .Select(element => new ValueDropdownItem
                                     {
                                         Text  = element.DisplayName ,
                                         Value = element.DataId
                                     });
            return valueDropdownItems;
        }

        public IUniqueId GetUniqueIdByIndex(int index)
        {
            if (index >= ids.Count) return null;
            var uniqueId = ids[index];
            return uniqueId;
        }

        public void RemoveData(string id)
        {
            var uniqueId = FindUniqueId(id);
            RemoveData(uniqueId);
        }

        public void RemoveData(U uniqueId)
        {
            ids.Remove(uniqueId);
            SetThisDirty();
        }

        public void SetThisDirty()
        {
            CustomEditorUtility.SetDirty(this);
        }

        [Button]
        [GUIColor(1f , 1f , 0f)]
        [BoxGroup("DataPath")]
        [ShowIf("IsDataScriptableObject")]
        public virtual void UpdateData()
        {
            ids = GetUniqueIds();
            SetThisDirty();
        }

        public virtual bool Validate(string id)
        {
            return ContainsId(id);
        }

    #endregion

    #region Protected Methods

        protected virtual bool ExtraCondition(U data)
        {
            return true;
        }


        protected U GetDataByIndex(int index)
        {
            if (index >= ids.Count) return default;
            return ids[index];
        }

        protected virtual string GetElementBoxText(int index)
        {
            var text = $"Index: {index}";
            return text;
        }

        protected List<U> GetUniqueIds()
        {
            var path              = useDataPath ? dataPath : "";
            var typeOfU           = typeof(U);
            var scriptableObjects = CustomEditorUtility.GetScriptableObjects(typeOfU , path);
            var uniqueIds         = scriptableObjects.Cast<U>().ToList();
            return uniqueIds;
        }

    #endregion

    #region Private Methods

        private U FindDataByDisplayName(string displayName)
        {
            var uniqueId = ids.Find(id => id.DisplayName == displayName);
            return uniqueId;
        }

        [UsedImplicitly]
        private bool IsDataScriptableObject()
        {
            var isSubclassOfRawGeneric = Utility.IsSubclassOfRawGeneric(typeof(ScriptableObject) , typeof(U));
            return isSubclassOfRawGeneric;
        }

    #endregion

    #if UNITY_EDITOR
        [UsedImplicitly]
        private void BeginListElementGUI(int index)
        {
            GUILayout.BeginHorizontal();
            var elementBoxText = GetElementBoxText(index);
            var guiContent     = new GUIContent(elementBoxText);
            var contentColor   = Color.cyan;
            GUI.contentColor = contentColor;
            SirenixEditorGUI.BeginBox(guiContent);
            GUI.contentColor = Color.white;
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