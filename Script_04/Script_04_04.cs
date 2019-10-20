using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unity脚本只支持单线程,利用协程模拟每隔一秒钟创建一个小方块.
public class Script_04_04:
MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CreateCube());
    }
    IEnumerator CreateCube()
    {
        for(int i = 0; i < 100 ; i++)
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = Vector3.one * i;
            yield return new WaitForSeconds(1f);
        }
    }
}
