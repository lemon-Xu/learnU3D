using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

//绘制源生Eidtor结构

public class Script_04_09_2:
MonoBehaviour
{
    [SerializeField]
    private int id;
    [SerializeField]
    private GameObject[] targets;
    [SerializeField]
    private GameObject[] targets2;
}

#if UNITY_EDITOR
[CustomEditor(typeof(Script_04_09))]
public class ScriptInsector1_2:
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
        //以默认样式绘制数组数据
        EditorGUILayout.PropertyField(serializedObject.FindProperty("targets"), true);
        //全部保存数据
        serializedObject.ApplyModifiedProperties();
    }
}
#endif