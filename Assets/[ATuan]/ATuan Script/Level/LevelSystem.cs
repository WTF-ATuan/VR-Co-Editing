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
            if (other.name == levelData.anserBullet.name)
            {
                levelData.pass = true;
            }
            else
                levelData.miss = true;
        }
        JudgeData();
    }
    public void JudgeData() {
        if (levelData.pass) {
        // pass image come out

        // pass sound come out
        }
        if (levelData.miss) {
        // miss sound come out 
        
        }
    }
}
