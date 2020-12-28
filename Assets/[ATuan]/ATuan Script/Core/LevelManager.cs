using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private ScenceData data;
    private List<LevelSet> levels;
    private List<BulletSet> bullets;
    private BulletSet nextBullet;
    [HideInInspector] public BulletSet currentBullet;
    private LevelSet nextLevel;
    [HideInInspector] public LevelSet currentLevel;
    public int currentLevelNumber;
    private int levelCount;

    public void Initialize(ScenceData scenceData)
    {
        data = scenceData;
        levels = scenceData.allLevelSets;
        bullets = scenceData.allBullets;
        levelCount = scenceData.allLevelSets.Count;
        AwakeLevel();
        UpdateEvent.AddUpdate(OnUpdate);
    }

    private void OnUpdate()
    {
        if (ScenceData.Data.LevelCount < 1)
        {
            data.IsPassLevel = true;
            data.OnPass.Invoke(null);
            return;
        }

        BulletUpdate(currentLevel, currentBullet);
        GameLoading();
        //forTest
        DebugInput();
    }
//forTest 資策會完刪掉
    private void DebugInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLevel.OnPassing.Invoke(null);
            EnemyBase enemy = GameObject.FindObjectOfType<EnemyBase>();
            enemy.pass = true;
            Debug.Log(enemy.pass);
        }
    }

    public void AwakeLevel()
    {
        if (levels == null || bullets == null)
            Debug.LogError("NotSetLevel or Bullet");
        currentBullet = bullets[0];
        currentLevel = levels[0];
        if (bullets.Count > 1 && levels.Count > 1)
        {
            nextBullet = bullets[1];
            nextLevel = levels[1];
        }

        currentLevelNumber = -1;
        if (currentLevel != null)
            currentLevelNumber++;
        if (nextLevel != null)
            currentLevelNumber++;
        SetData(currentLevel, currentBullet, data);
    }

    //OnReloading Enemy
    public void GameLoading()
    {
        if (BulletLoad() && LevelLoad())
            SetData(currentLevel, currentBullet, data);
    }

    private void SetData(LevelSet thisLevelset, BulletSet thisBulletset, ScenceData data)
    {
        data.currentLevelSet = thisLevelset;
        data.currentBulletSet = thisBulletset;
        data.LevelCount = levelCount;
    }

    private bool BulletLoad()
    {
        if (currentBullet != null)
            return true;
        if (nextBullet != null)
        {
            currentBullet = nextBullet;
            nextBullet = bullets[currentLevelNumber];
            return true;
        }

        return false;
    }

    private void BulletUpdate(LevelSet level, BulletSet bullet)
    {
        foreach (var levelData in level.LevelDatas)
        {
            if (levelData.pass)
            {
                BulletData bulletData = levelData.anserBullet;
                bullet.bullets.Remove(bulletData);
            }
        }
    }

    private bool LevelLoad()
    {
        bool thisLevelPass;
        if (currentLevel != null)
        {
            LevelUpdate(currentLevel, out thisLevelPass);
            if (thisLevelPass)
            {
                currentLevel.Enemy.pass = true;
                currentLevel = null;
                LevelLoad();
            }

            return true;
        }
        else
        {
            if (nextLevel != null)
            {
                currentLevel = nextLevel;
                currentLevelNumber++;
                nextLevel = levels[currentLevelNumber];
                return true;
            }
            else
                return false;
        }
    }

    private void LevelUpdate(LevelSet currentLevel, out bool pass)
    {
        bool isPass = true;
        foreach (var level in currentLevel.LevelDatas)
        {
            if (!level.pass)
            {
                isPass = false;
            }
        }

        if (isPass)
        {
            currentLevel.OnPassing.Invoke(null);
            levelCount--;
            pass = true;
        }
        pass = false;
    }
}