using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ScenceData scenesData;

    public void Initialize(ScenceData scenesData)
    {
        this.scenesData = scenesData;
        ReferenceDifficulty();
    }
    private void Start()
    {
        UpdateEvent.AddUpdate(GameTimeUpdate);
    }
    private void GameTimeUpdate()
    {
        scenesData.gameTime += Time.deltaTime;
    }
    private void ReferenceDifficulty() {
        scenesData.difficulty = new Difficulty();
        scenesData.difficulty = Difficulty.UnSet;
    }
    public void ResetGame()
    {
        scenesData.isPassLevel = false;
        scenesData.isFailLevel = false;
        scenesData.gameTime = 0;
    }
    public void SetDifficulty(Difficulty difficulty)
    {
        scenesData.difficulty = difficulty;
    }
    public void PassLevel() {
        scenesData.isPassLevel = true;
        scenesData.onPass.Invoke(null);
    }
    public void FailLevel() {
        scenesData.isFailLevel = true;
        scenesData.onFail.Invoke(null);
    }
}
