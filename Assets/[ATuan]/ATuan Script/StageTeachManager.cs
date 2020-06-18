using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Video;

public class StageTeachManager : MonoBehaviour {

    [Header("Importing Input")]
    [SerializeField] private ViveInput PlayerInput;

    [SerializeField] private GameObject[] TeachStageBubble;

    [SerializeField] private List<SetTrigger> TeachTrigger = new List<SetTrigger>();

    [SerializeField] private GameObject AnserOfTech;

    [SerializeField] private GameObject FirstWall;

    [SerializeField] private SteamVR_LoadLevel ScenceChanger;
    private bool IsOnLoad = false;

    [Header("UISetting")]

    [SerializeField] private Material[] UIMaterials;

    [SerializeField] private GameObject OnchangeUIGameObject;

    private Renderer UIRenderer;

    [Header("VideoSetting")]
    [SerializeField] GameObject Canvas;
    [SerializeField] private VideoPlayer video;
    private double FullTimeOfVideo, TimerOfVideo;

    [Header("SoundManager")]
    [SerializeField] private AudioSource OpenFireSound;
    [SerializeField] private AudioSource[] WordChange;
    [SerializeField] private AudioSource[] TriggerSound_Success;
    [SerializeField] private AudioSource[] TriggerSound_Fail;

    [Header("Debug")]
    public bool PassingTeachStage = false;
   

    private void Start() {
        ScenceChanger.enabled = false;
        FullTimeOfVideo = video.clip.length - 0.7;
        UIRenderer = OnchangeUIGameObject.GetComponent<Renderer>();
    }
    private void Update() {
        StageTeach();
    }
    public void StageTeach() {
        if (Canvas != null) {
            MovieController();
        }
        //順序
        //setBullet
        if (!IsOnLoad && SimpleReload.OnReload) {
            PlayerInput.fire.SetBullet(TeachStageBubble);
            IsOnLoad = true;
            //第一顆子彈隨機
            PlayerInput.fire.IndexOfBullet = Random.Range(0, TeachStageBubble.Length - 1);
        }          
        //判定子彈是否射到
        for (int i = 0; i < TeachTrigger.Count; i++) {
            if (TeachTrigger[i].Pass) {
                PlayerInput.fire.RemoveBullet(TeachTrigger[i].AnserObject.name);
                SphereCollider collider = TeachTrigger[i].gameObject.GetComponent<SphereCollider>();
                Destroy(collider);
            }
        }
        //檢查triggers是否都被擊中 
        bool cheak=true;
        foreach (SetTrigger triggers in TeachTrigger)
        {
            if (!triggers.Pass) {
                cheak = false;
                break;
            }
        }
        if (cheak)
        {
            Debug.Log("Passing");
            AnserOfTech.SetActive(true);
            PassingTeachStage = true;
        }
        if (SimpleReload.OnReload) {
            //牆壁往下
            FirstWall.transform.position = Vector3.Lerp(FirstWall.transform.position, new Vector3(FirstWall.transform.position.x, -3, FirstWall.transform.position.z), Time.deltaTime * 0.2f);
          
            //變更UI圖 
            MaterialChange();
        }
            //過關
        if (PassingTeachStage) {
            StartCoroutine(PassTeachStage());
        }

    }
    IEnumerator PassTeachStage() {
        //通關時要做的ｕｉ以及特效
        yield return new WaitForSeconds(3);
        ScenceChanger.enabled = true;
    }

    //public void PassTeachStage() {
    //    SceneManager.LoadScene(1);
    //}
    public void MaterialChange() {
        UIRenderer.material = UIMaterials[PlayerInput.fire.IndexOfBullet];
    }
    public void MovieController() {
        TimerOfVideo = video.time;
        if (TimerOfVideo >= FullTimeOfVideo) {
            video.Pause();
        }
        if (video.isPaused) {
            Canvas.transform.position = Vector3.Lerp(Canvas.transform.position, new Vector3(Canvas.transform.position.x, 7, Canvas.transform.position.z), Time.deltaTime * 0.2f);
            StartCoroutine(DeleteSelf(Canvas));
        }
       
    }
    IEnumerator DeleteSelf(GameObject gameObject) {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
