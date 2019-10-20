using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlobalTest:
MonoBehaviour
{
    Global global;

    void Awake()
    {
        global = new Global();
    }
}
