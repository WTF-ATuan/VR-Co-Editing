using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ScenceData scenceData;

    public void Initialize(ScenceData scenceData)
    {
        this.scenceData = scenceData;
        ReferenceDiffcultly();
    }
    private void Start()
    {
        UpdateEvent.AddUpdate(GameTimeUpdate);
    }
    private void GameTimeUpdate()
    {
        scenceData.GameTime += Time.deltaTime;
    }
    private void ReferenceDiffcultly() {
        scenceData.Difficulty = new Difficulty();
        scenceData.Difficulty = Difficulty.UnSet;
    }
    public void ResetGame()
    {
        scenceData.IsPassLevel = false;
        scenceData.IsFailLevel = false;
        scenceData.GameTime = 0;
    }
    public void SetDiffcultly(Difficulty difficulty)
    {
        scenceData.Difficulty = difficulty;
    }
    public void PassLevel() {
        scenceData.IsPassLevel = true;
        scenceData.OnPass.Invoke(null);
    }
    public void FailLevel() {
        scenceData.IsFailLevel = true;
        scenceData.OnFail.Invoke(null);
    }
}
