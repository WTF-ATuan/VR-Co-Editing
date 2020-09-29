using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelData))]
public class LevelSystem : MonoBehaviour
{
    LevelData levelData;
    private void Start()
    {
        if (levelData != null)
            return;
        levelData = GetComponent<LevelData>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other != null) {
            if (other.name == levelData.name)
            {
                levelData.pass = true;
            }
            else
                levelData.miss = true;
        }
    }
}
