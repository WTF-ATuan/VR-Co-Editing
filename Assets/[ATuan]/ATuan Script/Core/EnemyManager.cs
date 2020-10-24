using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyBase[] currentEnemyBase {
        get {
            UpdateEnemyCount();
            return currentEnemyBase; }
        set {
             value = currentEnemyBase;
        }
    }
    private ScenceData scenceData;
    public void Initialize(ScenceData scenceData) {
        this.scenceData = scenceData;
        SetEnemy();
    }
    private void UpdateEnemyCount() {
        scenceData.EnemyCount = currentEnemyBase.Length;
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
    }

}
