using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehavior<GameManager> {
    [SerializeField] private ViveInput inputManager;

    [Header("Level Manager")]
    [SerializeField] private bool FirstStage = false;
    [SerializeField] private bool SceondStage = false;
    [SerializeField] private bool ThirdStage = false;

    [Header("BubblePrefab")]
    [SerializeField] private GameObject[] StageOneBubble;
    [SerializeField] private GameObject[] StageTwoBubble;
    [SerializeField] private GameObject[] StageThreeBubble;

    [Header("BubbleTrigger")]
    [SerializeField] private List<SetTrigger> StageOneTrigger = new List<SetTrigger>();
    [SerializeField] private List<SetTrigger> StageTwoTrigger = new List<SetTrigger>();
    [SerializeField] private List<SetTrigger> StageThreeTrigger = new List<SetTrigger>();
    [Header("BoatPosition")]

    [SerializeField] private BoatSet boatSetting;
    [SerializeField] private List<Transform> BoatPosition = new List<Transform>();

    [Header("TranslateAnser")]
    [SerializeField] private GameObject AnserOne, AnserTwo, AnserThree;
    [Header("Question")]
    [SerializeField] private GameObject QuestionOne, QuestionTwo, QuestionThree;

    [Header("UIManager")]
    [SerializeField] UIManager uIManager;
    [SerializeField] GameObject OnFireUi;
    [SerializeField] GameObject[] StageOneUI;
    [SerializeField] GameObject[] StageTwoUI;
    [SerializeField] GameObject[] StageThreeUI;

    [Header("StartPosition")]
    [SerializeField] private Transform StartPos;
    private int RecycleNumber = 1;

    private int StageOneTriggerCount, StageTwoTriggerCount, StageThreeTriggerCount;

    private Stage stage;

    public void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Character");
        player.transform.position = StartPos.position;
        stage = Stage.FirstStage;
        StageOneTriggerCount = StageOneTrigger.Count;
        StageTwoTriggerCount = StageTwoTrigger.Count;
        StageThreeTriggerCount = StageThreeTrigger.Count;
    }
    public void Update() {
        switch (stage) {
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
        //UIsetting 在一開始就要出來了
        //Boatset 到點後
        //boatSetting.BoatMove((BoatPosition[RecycleNumber]), 5f);
        if(boatSetting.velocity == Vector3.zero)
        //setTrigger 並生成
        //setBullet
        if (RecycleNumber == 1) {
            inputManager.fire.SetBullet(StageOneBubble);
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = UnityEngine.Random.Range(0, StageOneBubble.Length - 1);
        }
        //判定子彈射到 以及關卡過
        for (int i = 0; i < StageOneTrigger.Count; i++) {
            if (StageOneTrigger[i].Pass) {
                Debug.Log(StageOneTrigger[i] + "Ispass");
                inputManager.fire.RemoveBullet(StageOneTrigger[i].AnserObject.name);
                StageOneTriggerCount -= 1;
                BoxCollider collider = StageOneTrigger[i].gameObject.GetComponent<BoxCollider>();
                collider.enabled = false;
            }
        }
        if (StageOneTriggerCount <= 0 || inputManager.fire.Magazine.Count <= 0) {
            StartCoroutine(SetTranslateOff(QuestionOne, FirstStage));
            AnserOne.SetActive(true);
            Debug.Log("Passing FirstStage");
        }

        if (FirstStage) {
            stage += 1;
        }

    }
    #endregion
    IEnumerator SetTranslateOff(GameObject obj , bool Stage) {
        yield return new WaitForSeconds(2);
        obj.SetActive(false);
        Stage = true;
    }

    public enum Stage {
        FirstStage,
        SceondStage,
        ThirdStage
    }
}
