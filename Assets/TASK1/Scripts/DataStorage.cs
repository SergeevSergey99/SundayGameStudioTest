using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    
    // This dictionary is used to store sprites downloaded from the server
    // optionally we can use string as a key, but int is more convenient
    public Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>();
    
    private void Awake()
    {
        if (FindObjectsOfType<DataStorage>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            StaticVariables.dataStorage = this;
        }
    }

    private void OnDestroy()
    {
        sprites.Clear();
        if (StaticVariables.dataStorage == this)
            StaticVariables.dataStorage = null;
    }
}
