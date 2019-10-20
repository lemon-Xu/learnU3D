using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// 在代码中访问私有属性
public class Script_04_08:
MonoBehaviour
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string name;
    [SerializeField]
    private GameObject prefab;

    public int age;

    [HideInInspector]
    public int sex;
}

#if UNITY_EDITOR
[CustomEditor(typeof(Script_04_08))]
public class ScriptInsector:
Editor
{
    public override void OnInspectorGUI()
    {
        //更新最新数据
        serializedObject.Update();
        //获取数据信息
        SerializedProperty property = serializedObject.FindProperty("id");
        //赋值数据
        property.intValue = EditorGUILayout.IntField("主键", property.intValue);
        property = serializedObject.FindProperty("name");
        property.stringValue = EditorGUILayout.TextField("姓名", property.stringValue);
        property = serializedObject.FindProperty("prefab");
        property.objectReferenceValue = EditorGUILayout.ObjectField("游戏对象", property.objectReferenceValue, typeof(GameObject), true);
        serializedObject.ApplyModifiedProperties();
    }
}
#endif