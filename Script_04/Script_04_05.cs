using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 停止协程任务
public class Script_04_05:
MonoBehaviour
{
    IEnumerator CreateCube()
    {
        for(int i = 0; i < 100; i++ )
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = Vector3.one * i;
            yield return new WaitForSeconds(1f);
        }
    }

    private Coroutine m_Coroutine = null;

    void OnGUI()
    {
        if(GUILayout.Button("StartCoroutine"))
        {
            if(m_Coroutine != null)
            {
                StartCoroutine(CreateCube());
            }
            m_Coroutine = StartCoroutine(CreateCube());
           
        }

        if(GUILayout.Button("StopCoroutine"))
        {
            if(m_Coroutine != null)
            {
                StopCoroutine(m_Coroutine);
            }
        }
    }
}
