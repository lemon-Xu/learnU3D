using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Global:
MonoBehaviour
{
    public static Global instance;

    static Global()
    {
        GameObject go = new GameObject("#Globa#");
        DontDestroyOnLoad(go);
        instance = go.AddComponent<Global>();
    }

    void Awake()
    {
       
    }

    public void DoSomeThings()
    {
        Debug.Log("DoSomeThings");
    }

    void Start()
    {
        Debug.Log("Start");
    }
}
