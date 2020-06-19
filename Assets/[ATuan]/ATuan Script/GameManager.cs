using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GameManager : SingletonMonoBehavior<GameManager> {
    private ViveInput inputManager;

    [Header("Level Manager")]
    [SerializeField] private bool FirstStage = false;
    [SerializeField] private bool SceondStage = false;
    [SerializeField] private bool ThirdStage = false;
    private SteamVR_LoadLevel ScenceManager;

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
    [SerializeField] private GameObject OnchangeUIGameObject;
    private Renderer UIRenderer;

    [Header("Animator")]
    [SerializeField] Animator LifeCircleAni;
    [SerializeField] Animator Man;
    [SerializeField] Animator Grandma;
    [SerializeField] Animator Lady;
    [SerializeField] GameObject[] LifeCorclePerson;

    [Header("StartPosition")]
    [SerializeField] private Transform StartPos;
    private int RecycleNumber = 1;
    private Stage stage;

    [Header("Sound")]
    public AudioSource successSound, failSound;

    public void Start() {
        SetPlayerPosition();
        inputManager.CheckingHand();
        stage = Stage.FirstStage;
        UIRenderer = OnchangeUIGameObject.GetComponent<Renderer>();
        ScenceManager = GetComponent<SteamVR_LoadLevel>();
        ScenceManager.enabled = false;
    }

    public void SetPlayerPosition() {
        GameObject player = GameObject.FindGameObjectWithTag("Character");
        inputManager = player.GetComponent<ViveInput>();
        player.transform.position = StartPos.position;
        player.transform.localRotation = StartPos.localRotation;
        player.transform.parent = boatSetting.gameObject.transform;
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
                StartCoroutine(EndingStage());
                break;
        }

    }
    #region Stage
    IEnumerator EndingStage() {
        yield return new WaitForSeconds(5f);
        ScenceManager.enabled = true;
    }
    public void StageThree() {
        if (ThirdStage) {
            stage += 1;
        }
    }
    public void StageTwo() {

        StartCoroutine(BoatMovement(2 , 3));

        if (RecycleNumber == 2) {
            inputManager.fire.SetBullet(StageTwoBubble);
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = 0;
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
            LifeCircleAni.SetTrigger("Life2");
            StartCoroutine(SetTranslateOff(QuestionTwo, SceondStage,Grandma));
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
        //Boatset 到點後
        StartCoroutine(BoatMovement(1 , 10));
        //setBullet
        if (RecycleNumber == 1) {
            inputManager.fire.SetBullet(StageOneBubble);
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = 0;
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
            LifeCircleAni.SetTrigger("Life1");
            StartCoroutine(SetTranslateOff(QuestionOne, FirstStage , Man));
            AnserOne.SetActive(true);
            Debug.Log("Passing FirstStage");
            //過關特效 以及聲音 動畫
        }
        if (FirstStage) {
            stage += 1;
        }

    }
    #endregion
    IEnumerator BoatMovement(int Stage , float time) {
        yield return new WaitForSeconds(time);
        boatSetting.BoatMove(BoatPosition[Stage - 1].position, 5f);
    }
    IEnumerator SetTranslateOff(GameObject obj , bool Stage , Animator animator) {
        obj.transform.position = Vector3.Lerp(obj.transform.position, new Vector3(obj.transform.position.x, obj.transform.position.y + 5f, obj.transform.position.z), Time.deltaTime * 0.2f);
        animator.SetTrigger("SaveLIfe");
        yield return new WaitForSeconds(10);
        obj.SetActive(false);
        Stage = true;
    }
    public enum Stage {
        FirstStage,
        SceondStage,
        ThirdStage
    }
}
