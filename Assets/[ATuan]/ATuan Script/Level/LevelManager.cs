using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonMonoBehavior<LevelManager>
{
    public List<LevelSet> AllLevels;
    public List<BulletSet> AllBullets;
    [HideInInspector]
    public BulletSet nextBullet;
    [HideInInspector]
    public BulletSet currentBullet;
    [HideInInspector]
    public LevelSet nextLevel;
    [HideInInspector]
    public LevelSet currentLevel;
    public int currentLevelNumber;

    public void Start()
    {
        currentLevelNumber = -1;
        if (currentLevel != null)
            currentLevelNumber++;
        if (nextLevel != null)
            currentLevelNumber++;
    }
    public void LevelLoad()
    {
        bool thisLevelPass;
        if (currentLevel != null)
        {
            LevelUpdate(currentLevel, out thisLevelPass);
            if (thisLevelPass)
            {
                currentLevel = null;
                thisLevelPass = false;
            }
        }
        else
        {
            if (nextLevel != null)
            {
                currentLevel = nextLevel;
                currentLevelNumber++;
                nextLevel = AllLevels[currentLevelNumber];
            }
            else
                Debug.LogError("MissingNextLevel");

        }

    }

    public void LevelUpdate(LevelSet currentLevel, out bool pass)
    {
        bool isPass = true;
        foreach (var item in currentLevel.LevelDatas)
        {
            if (item.pass)
                isPass = false;
        }
        if (isPass)
        {
            currentLevel.OnPassing.Invoke(null);
            pass = true;
        }
        pass = false;
    }
}
