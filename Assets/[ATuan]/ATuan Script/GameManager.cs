using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    private ViveInput inputManager;

    [Header("Level Manager")]
    [SerializeField] private bool FirstStage = false;
    [SerializeField] private bool SceondStage = false;
    [SerializeField] private bool ThirdStage = false;
    [SerializeField] private SteamVR_LoadLevel ScenceChange;

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
    public AudioSource[] TaiwanSound;
    public AudioSource[] japanSoundOne;
    public AudioSource[] japanSoundTwo;
    public AudioSource[] japanSoundThree;

    public void Start()
    {
        SetPlayerPosition();
        inputManager.CheckingHand();
        stage = Stage.FirstStage;
        UIRenderer = OnchangeUIGameObject.GetComponent<Renderer>();
        ScenceChange.enabled = false;
    }

    public void SetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Character");
        inputManager = player.GetComponent<ViveInput>();
        player.transform.position = StartPos.position;
        player.transform.localRotation = StartPos.localRotation;
        player.transform.parent = boatSetting.gameObject.transform;
    }
    public void Update()
    {
        switch (stage)
        {
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
        if (ThirdStage) {
            Invoke("EndingStage", 3f);
        }
    }
    #region Stage
    void EndingStage()
    {
        ScenceChange.enabled = true;
        Destroy(this);
    }
    public void StageThree()
    {
        StartCoroutine(BoatMovement(3, 5));

        if (RecycleNumber == 3)
        {
            inputManager.fire.SetBullet(StageThreeBubble);
            inputManager.fire.animator.SetTrigger("OnChangeBullet");
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = 0;
        }
        UIRenderer.material = StageThreeUI[inputManager.fire.IndexOfBullet];
        japanSoundThree[inputManager.fire.IndexOfBullet].Play();

        bool check = true;
        foreach (SetTrigger triggers in StageThreeTrigger)
        {
            if (!triggers.Pass)
            {
                check = false;
                break;
            }
        }
        if (check || Input.GetKeyDown(KeyCode.T))
        {
            LifeCircleAni.SetTrigger("Life3");
            StartCoroutine(SetTranslateOff(QuestionThree, ThirdStage));
            QuestionThree.transform.position = Vector3.Lerp(QuestionThree.transform.position, new Vector3(QuestionThree.transform.position.x, QuestionThree.transform.position.y + 5f, QuestionThree.transform.position.z), Time.deltaTime * 0.2f);
            AnimatorSetting(Grandma, 2);
            AnserOne.SetActive(true);
            Debug.Log("Passing ThreeStage");
            //過關特效 以及聲音
            SoundChanger(TaiwanSound[2]);
            ThirdStage = true;
        }
        if (ThirdStage)
        {
            stage += 1;
        }
    }
    public void StageTwo()
    {
        StartCoroutine(BoatMovement(2, 5));

        if (RecycleNumber == 2)
        {
            inputManager.fire.SetBullet(StageTwoBubble);
            inputManager.fire.animator.SetTrigger("OnChangeBullet");
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = 0;
        }
        UIRenderer.material = StageTwoUI[inputManager.fire.IndexOfBullet];
        japanSoundTwo[inputManager.fire.IndexOfBullet].Play();
        bool check = true;
        foreach (SetTrigger triggers in StageTwoTrigger)
        {
            if (!triggers.Pass)
            {
                check = false;
                break;
            }
        }
        if (check || Input.GetKeyDown(KeyCode.S))
        {
            LifeCircleAni.SetTrigger("Life2");
            StartCoroutine(SetTranslateOff(QuestionTwo, SceondStage));
            QuestionTwo.transform.position = Vector3.Lerp(QuestionTwo.transform.position, new Vector3(QuestionTwo.transform.position.x, QuestionTwo.transform.position.y + 5f, QuestionTwo.transform.position.z), Time.deltaTime * 0.2f);
            AnimatorSetting(Grandma, 1);
            AnserOne.SetActive(true);
            Debug.Log("Passing SceondStage");
            //過關特效 以及聲音
            SoundChanger(TaiwanSound[1]);
            SceondStage = true;
        }     
        if (SceondStage)
        {
            stage += 1;
        }

    }
    public void StageOne()
    {
        //順序
        inputManager.RightHand.AttachObject(inputManager.LoudPublic, inputManager.StartGrab, inputManager.attachmentFlags);

        //Boatset 到點後
        StartCoroutine(BoatMovement(1, 10));
        //setBullet
        if (RecycleNumber == 1)
        {
            inputManager.fire.SetBullet(StageOneBubble);
            inputManager.fire.animator.SetTrigger("OnChangeBullet");
            RecycleNumber++;
            inputManager.fire.IndexOfBullet = 0;
        }
        UIRenderer.material = StageOneUI[inputManager.fire.IndexOfBullet];
        japanSoundOne[inputManager.fire.IndexOfBullet].Play();
        bool check = true;
        foreach (SetTrigger triggers in StageOneTrigger)
        {
            if (!triggers.Pass)
            {
                check = false;
                break;
            }
        }
        if (check || Input.GetKeyDown(KeyCode.F))
        {
            LifeCircleAni.SetTrigger("Life1");
            StartCoroutine(SetTranslateOff(QuestionOne, FirstStage));
            QuestionOne.transform.position = Vector3.Lerp(QuestionOne.transform.position, new Vector3(QuestionOne.transform.position.x, QuestionOne.transform.position.y + 5f, QuestionOne.transform.position.z), Time.deltaTime * 0.2f);
            AnimatorSetting(Man, 0);
            AnserOne.SetActive(true);
            Debug.Log("Passing FirstStage");
            FirstStage = true;
            //過關特效 以及聲音 動畫
            SoundChanger(TaiwanSound[0]);
        }
        if (FirstStage)
        {
            stage += 1;
        }

    }
    #endregion
    void SoundChanger(AudioSource audio)
    {
        audio.Play();
    }

    IEnumerator BoatMovement(int Stage, float time)
    {
        yield return new WaitForSeconds(time);
        boatSetting.BoatMove(BoatPosition[Stage - 1].position, 5f);
    }
    IEnumerator AnimatorSetting(Animator animator, int num)
    {
        animator.SetTrigger("SaveLIfe");
        yield return new WaitForSeconds(1);
        LifeCorclePerson[num].SetActive(true);

    }
    IEnumerator SetTranslateOff(GameObject obj, bool Stage)
    {
        obj.transform.position = Vector3.Lerp(obj.transform.position, new Vector3(obj.transform.position.x, obj.transform.position.y + 5f, obj.transform.position.z), Time.deltaTime * 0.2f);
        yield return new WaitForSeconds(5);
        obj.SetActive(false);
        Stage = true;
    }
    public enum Stage
    {
        FirstStage,
        SceondStage,
        ThirdStage
    }
}
