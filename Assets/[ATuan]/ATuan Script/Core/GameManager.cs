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
        scenesData.GameTime += Time.deltaTime;
    }
    private void ReferenceDifficulty() {
        scenesData.Difficulty = new Difficulty();
        scenesData.Difficulty = Difficulty.UnSet;
    }
    public void ResetGame()
    {
        scenesData.IsPassLevel = false;
        scenesData.IsFailLevel = false;
        scenesData.GameTime = 0;
    }
    public void SetDifficulty(Difficulty difficulty)
    {
        scenesData.Difficulty = difficulty;
    }
    public void PassLevel() {
        scenesData.IsPassLevel = true;
        scenesData.OnPass.Invoke(null);
    }
    public void FailLevel() {
        scenesData.IsFailLevel = true;
        scenesData.OnFail.Invoke(null);
    }
}
