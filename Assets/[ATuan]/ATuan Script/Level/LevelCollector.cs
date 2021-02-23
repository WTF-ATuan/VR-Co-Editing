using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollector : MonoBehaviour
{
    [MyReadOnly] public bool passing;
    public List<LevelData> levels;

    private void Start()
    {
        levels = new List<LevelData>(GetComponentsInChildren<LevelData>());
        UpdateEvent.AddUpdate(ToUpdate);
    }

    private void ToUpdate()
    {
        var isPass = false;
        foreach (var level in levels)
        {
            if (!level.pass)
                isPass = true;
        }
        if (!isPass)
            passing = true;
    }
}