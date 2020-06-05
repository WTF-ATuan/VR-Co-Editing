using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager> {
    
    
    [SerializeField] private ViveInput inputManager;
    

    [Header("Level Manager")]
    [SerializeField] private bool TeachStage = false;
    [SerializeField] private bool FirstStage = false;
    [SerializeField] private bool SceondStage = false;
    [SerializeField] private bool ThirdStage = false;

    [Header("BubblePrefab")]
    [SerializeField] private GameObject[] TeachStagePrefab;
    [SerializeField] private GameObject[] StageOnePrefab;
    [SerializeField] private GameObject[] StageTwoPrefab;
    [SerializeField] private GameObject[] StageThreePrefab;

    [Header("BubbleTrigger")]
    [SerializeField] private List<SetTrigger> TeachTrigger = new List<SetTrigger>();
    [SerializeField] private List<SetTrigger> StageOneTrigger = new List<SetTrigger>();
    [SerializeField] private List<SetTrigger> StageTwoTrigger = new List<SetTrigger>();
    [SerializeField] private List<SetTrigger> StageThreeTrigger = new List<SetTrigger>();




    private Stage stage;

    public void Start() {
        stage = Stage.TeachStage;
    }
    public void Update() {
        switch (stage) {
            case Stage.TeachStage:
                StageTeach();
                break;
            case Stage.FirstStage:
                StageOne();
                break;
            case Stage.SceondStage:
                StageTwo();
                break;
            case Stage.ThirdStage:
                StageThree();
                break;
            default:
                break;
        }

    }
    #region Stage
    public void StageThree() {
    
    }
    public void StageTwo() {
    
    }
    public void StageOne() {

        
    }
    public void StageTeach() {

        if (TeachStage)
            stage += 1;
    }
    #endregion

    public void TriggerPass() {
    
    }

    public enum Stage {
        TeachStage,
        FirstStage,
        SceondStage,
        ThirdStage
    }
}
