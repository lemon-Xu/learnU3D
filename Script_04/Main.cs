using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main:
MonoBehaviour
{
    void Start(){
        Script_04_12 script = Resources.Load<Script_04_12>("New Script_04_12");
        Debug.LogFormat("name: {0} id: {1}", script.m_PlayerInfo [0].name, script.m_PlayerInfo [0].id);
        Debug.Log(script);
    }
}
