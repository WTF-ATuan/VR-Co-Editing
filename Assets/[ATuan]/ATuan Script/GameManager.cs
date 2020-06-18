using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehavior<GameManager> {
    private ViveInput inputManager;

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
    [SerializeField] private Material[] StageOneUI;
    [SerializeField] private Material[] StageTwoUI;
    [SerializeField] private Material[] StageThreeUI;

    [Header("Animator")]
    [SerializeField] Animator Man;
    [SerializeField] Animator Grandma;
    [SerializeField] Animator Lady;

    [Header("StartPosition")]
    [SerializeField] private Transform StartPos;
    private int RecycleNumber = 1;
    private Stage stage;

    public void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Character");
        inputManager = player.GetComponent<ViveInput>();
        player.transform.position = StartPos.position;
        player.transform.parent = boatSetting.gameObject.transform;
        stage = Stage.FirstStage;
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

        StartCoroutine(BoatMovement(2));

        if (RecycleNumber == 2) {
            inputManager.fire.SetBullet(StageTwoBubble);
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = UnityEngine.Random.Range(0, StageTwoBubble.Length - 1);
        }

        for (int i = 0; i < StageTwoTrigger.Count; i++) {
            if (StageOneTrigger[i].Pass) {
                inputManager.fire.RemoveBullet(StageTwoTrigger[i].AnserObject.name);
                SphereCollider collider = StageOneTrigger[i].gameObject.GetComponent<SphereCollider>();
                collider.enabled = false;
            }
        }
        bool check = true;
        foreach (SetTrigger triggers in StageTwoTrigger) {
            if (!triggers.Pass) {
                check = false;
                break;
            }
        }
        if (check) {
            StartCoroutine(SetTranslateOff(QuestionTwo, SceondStage));
            AnserOne.SetActive(true);
            Debug.Log("Passing SceondStage");
            //過關特效 以及聲音
        }
        if (SceondStage) {
            stage += 1;
        }

    }
    public void StageOne() {
        //順序
        //UIsetting 在一開始就要出來了
        //Boatset 到點後
        StartCoroutine(BoatMovement(1));
        //setBullet
        if (RecycleNumber == 1) {
            inputManager.fire.SetBullet(StageOneBubble);
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = UnityEngine.Random.Range(0, StageOneBubble.Length - 1);
        }
        //判定子彈射到 以及關卡過
        for (int i = 0; i < StageOneTrigger.Count; i++) {
            if (StageOneTrigger[i].Pass) {
                inputManager.fire.RemoveBullet(StageOneTrigger[i].AnserObject.name);
                SphereCollider collider = StageOneTrigger[i].gameObject.GetComponent<SphereCollider>();
                collider.enabled = false;
            }
        }
        bool check = true;
        foreach (SetTrigger triggers in StageOneTrigger) {
            if (!triggers.Pass) {
                check = false;
                break;
            }
        }
        if (check) {
            StartCoroutine(SetTranslateOff(QuestionOne, FirstStage));
            AnserOne.SetActive(true);
            Debug.Log("Passing FirstStage");
            //過關特效 以及聲音 動畫
        }
        if (FirstStage) {
            stage += 1;
        }

    }
    #endregion
    IEnumerator BoatMovement(int Stage) {
        boatSetting.BoatMove(BoatPosition[Stage - 1].position, 5f);
        yield return new WaitForSeconds(5);
    }
    IEnumerator SetTranslateOff(GameObject obj , bool Stage) {
        obj.transform.position = Vector3.Lerp(obj.transform.position, new Vector3(obj.transform.position.x, obj.transform.position.y + 5f, obj.transform.position.z), 5f);
        yield return new WaitForSeconds(5);
        obj.SetActive(false);
        Stage = true;
    }
    public enum Stage {
        FirstStage,
        SceondStage,
        ThirdStage
    }
}
