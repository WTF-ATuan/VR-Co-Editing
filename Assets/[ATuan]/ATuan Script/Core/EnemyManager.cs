using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyBase[] currentEnemyBase;
    private ScenceData scenceData;
    public void Initialize(ScenceData scenceData) {
        this.scenceData = scenceData;
        SetEnemy();
        UpdateEvent.AddUpdate(UpdateEnemyCount);
    }
    private void UpdateEnemyCount() {
        scenceData.EnemyCount = currentEnemyBase.Length;
        if (scenceData.EnemyCount <= 0) {
            scenceData.IsPassLevel = true;
        }
    }
    private void SetEnemy() {
        if (currentEnemyBase != null)
            return;
        if (scenceData.Difficulty == Difficulty.Easy)
            currentEnemyBase = scenceData.EasyVersion;
        if (scenceData.Difficulty == Difficulty.Normal)
            currentEnemyBase = scenceData.NormalVersion;
        if (scenceData.Difficulty == Difficulty.Hard)
            currentEnemyBase = scenceData.HardVersion;
        foreach (var item in currentEnemyBase)
        {
            scenceData.thisLevel.Add(item.levels);
            scenceData.thisBullets.Add(item.bullets);
        }
    }

}
