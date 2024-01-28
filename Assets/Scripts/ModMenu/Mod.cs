using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod : MonoBehaviour
{
    public string mode;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
