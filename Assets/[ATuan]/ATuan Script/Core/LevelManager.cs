using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
// ReSharper disable All

// public class LevelManager : MonoBehaviour
// {
//     private ScenceData data;
//     private List<LevelSet> levels;
//     private List<BulletSet> bullets;
//     private BulletSet nextBullet;
//     [HideInInspector] public BulletSet currentBullet;
//     private LevelSet nextLevel;
//     [HideInInspector] public LevelSet currentLevel;
//     [MyReadOnly]
//     public int currentLevelNumber;
//     private int levelCount;
//
//     public void Initialize(ScenceData scenceData)
//     {
//         data = scenceData;
//         levels = scenceData.allLevelSets;
//         bullets = scenceData.allBullets;
//         levelCount = scenceData.allLevelSets.Count;
//         AwakeLevel();
//         UpdateEvent.AddUpdate(OnUpdate);
//     }
//
//     private void OnUpdate()
//     {
//         if (ScenceData.Data.levelCount < 1)
//         {
//             data.IsPassLevel = true;
//             data.OnPass.Invoke(null);
//             return;
//         }
//
//         BulletUpdate(currentLevel, currentBullet);
//         GameLoading();
//     }
//
//     public void AwakeLevel()
//     {
//         if (levels == null || bullets == null)
//             Debug.LogError("NotSetLevel or Bullet");
//         currentBullet = bullets[0];
//         currentLevel = levels[0];
//         if (bullets.Count > 1 && levels.Count > 1)
//         {
//             nextBullet = bullets[1];
//             nextLevel = levels[1];
//         }
//
//         currentLevelNumber = -1;
//         if (currentLevel != null)
//             currentLevelNumber++;
//         if (nextLevel != null)
//             currentLevelNumber++;
//         SetData(currentLevel, currentBullet, data);
//     }
//
//     //OnReloading Enemy
//     public void GameLoading()
//     {
//         if (BulletLoad() && LevelLoad())
//             SetData(currentLevel, currentBullet, data);
//     }
//
//     private void SetData(LevelSet thisLevelSet, BulletSet thisBulletSet, ScenceData data)
//     {
//         data.currentLevelSet = thisLevelSet;
//         data.currentBulletSet = thisBulletSet;
//         data.levelCount = levelCount;
//     }
//
//     private bool BulletLoad()
//     {
//         if (currentBullet != null)
//             return true;
//         if (nextBullet != null)
//         {
//             currentBullet = nextBullet;
//             nextBullet = bullets[currentLevelNumber];
//             return true;
//         }
//
//         return false;
//     }
//
//     private void BulletUpdate(LevelSet level, BulletSet bullet)
//     {
//         foreach (var levelData in level.levelData)
//         {
//             if (levelData.pass)
//             {
//                 BulletData bulletData = levelData.answerBullet;
//                 bullet.bullets.Remove(bulletData);
//             }
//         }
//     }
//
//     private bool LevelLoad()
//     {
//         bool isLevelPass;
//         if (currentLevel != null)
//         {
//             LevelUpdate(currentLevel, out isLevelPass);
//             if (isLevelPass)
//             {
//                 currentLevel.pass = true;
//                 currentLevel = null;
//                 LevelLoad();
//             }
//
//             return true;
//         }
//         else
//         {
//             if (nextLevel != null)
//             {
//                 currentLevel = nextLevel;
//                 currentLevelNumber++;
//                 nextLevel = levels[currentLevelNumber];
//                 return true;
//             }
//             else
//                 return false;
//         }
//     }
//
//     private void LevelUpdate(LevelSet currentLevel, out bool pass)
//     {
//         bool isPass = true;
//         foreach (var level in currentLevel.levelData)
//         {
//             if (!level.pass)
//             {
//                 isPass = false;
//             }
//         }
//
//         if (isPass)
//         {
//             levelCount--;
//             pass = true;
//         }
//         pass = false;
//     }
// }