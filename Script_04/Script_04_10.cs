using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

//监听部分元素修改事件
public class Script_04_10:
MonoBehaviour
{
    [SerializeField]
    private GameObject[] targets;
}

#if UNITY_EDITOR
[CustomEditor(typeof(Script_04_10))]
public class ScriptInsector2:
Editor
{
    public override void OnInspectorGUI()
    {
        //更新最新数据
        serializedObject.Update();
        //标记检查
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("targets"), true);
        //标记检查发生变化
        if(EditorGUI.EndChangeCheck()) {
            Debug.Log("元素发生变化");
        }
        //判断面板元素是否任意发生变化
        if(GUI.changed){

        }
        //全部保存数据
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
