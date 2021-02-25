using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollector : MonoBehaviour{
    public bool Passing => IsPassLevel();
    public List<LevelData> levels;

    private void Start()
    {
        levels = new List<LevelData>(GetComponentsInChildren<LevelData>());
    }
    

    private bool IsPassLevel(){
        var isPass = false;
        foreach (var level in levels)
        {
            if (!level.pass)
                isPass = true;
        }
        return isPass;
    }
}