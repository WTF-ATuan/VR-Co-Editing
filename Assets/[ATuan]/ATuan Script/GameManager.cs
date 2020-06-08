using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehavior<GameManager> {
    [SerializeField] private List<TeleportPoint> teleportPoints = new List<TeleportPoint>();
    [SerializeField] private ViveInput inputManager;

    [Header("Level Manager")]
    [SerializeField] private bool TeachStage = false;
    [SerializeField] private bool FirstStage = false;
    [SerializeField] private bool SceondStage = false;
    [SerializeField] private bool ThirdStage = false;

    [Header("BubblePrefab")]
    [SerializeField] private GameObject[] TeachStageBubble;
    [SerializeField] private GameObject[] StageOneBubble;
    [SerializeField] private GameObject[] StageTwoBubble;
    [SerializeField] private GameObject[] StageThreeBubble;

    [Header("BubbleTrigger")]
    [SerializeField] private List<SetTrigger> TeachTrigger = new List<SetTrigger>();
    [SerializeField] private List<SetTrigger> StageOneTrigger = new List<SetTrigger>();
    [SerializeField] private List<SetTrigger> StageTwoTrigger = new List<SetTrigger>();
    [SerializeField] private List<SetTrigger> StageThreeTrigger = new List<SetTrigger>();
    [Header("BoatPosition")]
    [SerializeField] private BoatSet boatSetting;
    [SerializeField] private List<Vector3> BoatPosition = new List<Vector3>();


    private int RecycleNumber = 0;

    public int TeachTriggerCount, StageOneTriggerCount, StageTwoTriggerCount, StageThreeTriggerCount;

    private Stage stage;

    public void Start() {
        stage = Stage.TeachStage;
        TeachTriggerCount = TeachTrigger.Count;
        StageOneTriggerCount = StageOneTrigger.Count;
        StageTwoTriggerCount = StageTwoTrigger.Count;
        StageThreeTriggerCount = StageThreeTrigger.Count;
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
                EndingStage();
                break;
        }

    }
    #region Stage
    public void EndingStage() {

    }
    public void StageThree() {
        if (ThirdStage) {
            stage += 1;
        }
    }
    public void StageTwo() {
        if (SceondStage) {
            stage += 1;
        }

    }
    public void StageOne() {
        //順序
        //Boatset 到點後 
        //setTrigger 並生成
        //setBullet
        if (RecycleNumber == 1) {
            inputManager.fire.SetBullet(StageOneBubble);
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = StageOneBubble.Length;
        }
        //判定子彈射到 以及關卡過
        for (int i = 0; i < StageOneTrigger.Count; i++) {
            if (StageOneTrigger[i].Pass) { 
                inputManager.fire.RemoveBullet(StageOneTrigger[i].PassObjcet);
                StageOneTriggerCount -= 1;
                if (StageOneTriggerCount <= 0 || inputManager.fire.Magazine.Count <= 0) {
                    FirstStage = true;
                    Debug.Log("Passing FirstStage");
                }

            }
        }

        if (FirstStage) {
            stage += 1;
        }

    }
    public void StageTeach() {
        //set trigger  要把set trigger的gameobject生出來 , 加上新的compoet  (可以做成方法 , 會需要一個gameobject的List)
        //順序
        //setTrigger 並生成(等prefab)

        //setBullet
        if (RecycleNumber == 0) {
            inputManager.fire.SetBullet(TeachStageBubble);
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = TeachStageBubble.Length;
        }
        //判定子彈是否射到
        for (int i = 0; i < TeachTrigger.Count; i++) {
            if (TeachTrigger[i].Pass) {
                inputManager.fire.RemoveBullet(TeachTrigger[i].PassObjcet);
                TeachTriggerCount -= 1;
                if (TeachTriggerCount <= 0 || inputManager.fire.Magazine.Count <= 0) {
                    TeachStage = true;
                    Debug.Log("Passing TeachStage");
                }

            }
        }
        //判定子彈沒了or SetTrigger 都擊中了
        if (TeachStage) {
            SceneManager.LoadScene(1);
            stage += 1;
        }

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
