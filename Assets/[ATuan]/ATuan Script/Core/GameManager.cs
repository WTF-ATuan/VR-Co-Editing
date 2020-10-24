using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ScenceData scenceData;
    public static void ResetGameTime(ScenceData scenceData) {
        scenceData.GameTime = 0;
    }
    public static void SetDiffcultly(ScenceData scenceData , Difficulty difficulty) {
        scenceData.Difficulty = difficulty;
    }

    public void Initialize(ScenceData scenceData)
    {
        this.scenceData = scenceData;
        SetGameDiffcultly();
        UpdateEvent.AddUpdate(GameTimeUpdate);
    }
    private void GameTimeUpdate()
    {
        scenceData.GameTime += Time.deltaTime;
    }
    private void SetGameDiffcultly() {
        scenceData.Difficulty = new Difficulty();
        scenceData.Difficulty = Difficulty.UnSet;
    }
}
