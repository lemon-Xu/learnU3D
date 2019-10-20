using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// 序列化与反序列化
public class Script_04_11:
MonoBehaviour, 
ISerializationCallbackReceiver
{
    [SerializeField]
    private List<Sprite> m_Values = new List<Sprite>();
    [SerializeField]
    private List<string> m_Keys = new List<string>();

    public Dictionary<string, Sprite> SpriteDic = new Dictionary<string, Sprite>();

    #region ISerializationCallbackReceiver implementation
    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        // 序列化
        m_Keys.Clear();
        m_Values.Clear();
        foreach(KeyValuePair<string, Sprite> pair in SpriteDic){
            m_Keys.Add(pair.Key);
            m_Values.Add(pair.Value);
        }
    }

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        //反序列化
        SpriteDic.Clear();
        if(m_Keys.Count != m_Values.Count){
            Debug.LogError("m_Keys and m_Values 长度不匹配");
        } else {
            for(int i = 0; i < m_Keys.Count; i++){
                SpriteDic[m_Keys [i]] = m_Values[i];

            }
        }

    }
    #endregion

    
    #if UNITY_EDITOR
    [CustomEditor(typeof(Script_04_11))]
    public class ScriptInsector11:
    Editor
    {
        public override void OnInspectorGUI()
        {
            //更新最新数据
            serializedObject.Update();
            SerializedProperty propertyKey = serializedObject.FindProperty("m_Keys");
            SerializedProperty propertyValue = serializedObject.FindProperty("m_Values");

            int size = propertyKey.arraySize;

            GUILayout.BeginVertical();
            for(int i = 0; i < size; i++){
                GUILayout.BeginHorizontal();
                SerializedProperty key = propertyKey.GetArrayElementAtIndex(i);
                SerializedProperty value = propertyValue.GetArrayElementAtIndex(i);
                key.stringValue = EditorGUILayout.TextField("key", key.stringValue);
                value.objectReferenceValue = EditorGUILayout.ObjectField("value", value.objectReferenceValue, typeof(Sprite), false);
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal();
            if(GUILayout.Button("+")){
                // (target as Script_04_11).spriteDic [size.ToString()] = null;
            }
            GUILayout.EndHorizontal();
            //全部保存数据
            serializedObject.ApplyModifiedProperties();
        }
    }
    #endif

}
