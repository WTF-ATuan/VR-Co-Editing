using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{

    [SerializeField] private ViveInput inputManager;
    [SerializeField] private BoatSet boatSetting;
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

    public int TeachTriggerCount, StageOneTriggerCount, StageTwoTriggerCount, StageThreeTriggerCount;

    private Stage stage;

    public void Start()
    {
        stage = Stage.TeachStage;
        TeachTriggerCount = TeachTrigger.Count;
        StageOneTriggerCount = StageOneTrigger.Count;
        StageTwoTriggerCount = StageTwoTrigger.Count;
        StageThreeTriggerCount = StageThreeTrigger.Count;
    }
    public void Update()
    {
        switch (stage)
        {
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
                EndingStage();
                break;
        }

    }
    #region Stage
    public void EndingStage()
    {

    }
    public void StageThree()
    {
        if (ThirdStage)
        {
            stage += 1;
        }
    }
    public void StageTwo()
    {
        if (SceondStage)
        {
            stage += 1;
        }

    }
    public void StageOne()
    {
        if (FirstStage)
        {
            stage += 1;
        }

    }
    public void StageTeach()
    {
        //set trigger  要把set trigger的gameobject生出來 , 加上新的compoet  (可以做成方法 , 會需要一個gameobject的List)

        if (TeachStage)
        {
            stage += 1;
        }

    }
    #endregion

    public void TriggerPass()
    {

    }

    public enum Stage
    {
        TeachStage,
        FirstStage,
        SceondStage,
        ThirdStage
    }
}
