using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StageTeachManager : MonoBehaviour {

    [Header("Importing Input")]
    [SerializeField] private ViveInput PlayerInput;

    [SerializeField] private GameObject[] TeachStageBubble;

    [SerializeField] private List<SetTrigger> TeachTrigger = new List<SetTrigger>();

    [SerializeField] private GameObject AnserOfTech;

    [SerializeField] private GameObject FirstWall;

    [Header("UISetting")]

    [SerializeField] private Material[] UIMaterials;

    [SerializeField] private GameObject OnchangeUIGameObject;

    private MeshRenderer UIMesh;

    [Header("VideoSetting")]
    [SerializeField] GameObject Canvas;
    [SerializeField] private VideoPlayer video;
    private double FullTimeOfVideo, TimerOfVideo;

    private int TeachTriggerCount;
    private bool IsOnLoad = false;
    public bool PassingTeachStage = false;
    private void Start() {
        TeachTriggerCount = TeachTrigger.Count;
        FullTimeOfVideo = video.clip.length - 0.7;
        UIMesh = OnchangeUIGameObject.GetComponent<MeshRenderer>();
    }
    private void Update() {
        StageTeach();
    }
    public void StageTeach() {
        MovieController();
        //順序
        //setBullet
        if (!IsOnLoad && SimpleReload.OnReload) {
            PlayerInput.fire.SetBullet(TeachStageBubble);
            IsOnLoad = true;
            PlayerInput.fire.IndexOfBullet = UnityEngine.Random.Range(0, TeachStageBubble.Length - 1);
            MaterialChange();
        }
        //牆壁往下
        if (SimpleReload.OnReload) {
            FirstWall.transform.position = Vector3.Lerp(FirstWall.transform.position, new Vector3(FirstWall.transform.position.x, -3, FirstWall.transform.position.z), Time.deltaTime * 0.2f);
        }
        //判定子彈是否射到
        for (int i = 0; i < TeachTrigger.Count; i++) {
            if (TeachTrigger[i].Pass) {
                PlayerInput.fire.RemoveBullet(TeachTrigger[i].AnserObject.name);
                TeachTrigger[i].ChangeImage();
                TeachTriggerCount -= 1;
                BoxCollider collider = TeachTrigger[i].GetComponent<BoxCollider>();
                collider.enabled = false;
            }
        }
        if (SimpleReload.OnReload) {
            if (TeachTriggerCount <= 0 || PlayerInput.fire.Magazine.Count <= 0) {
                AnserOfTech.SetActive(true);
                PassingTeachStage = true;
                Debug.Log("Passing TeachStage");
            }
        }

        if (PassingTeachStage)
            PassTeachStage();


        IEnumerator PassTeachStage() {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(1);
        }

    }
    public void MaterialChange() {
        UIMesh.material = UIMaterials[PlayerInput.fire.IndexOfBullet];
    }
    public void MovieController() {
        TimerOfVideo = video.time;
        if (TimerOfVideo >= FullTimeOfVideo) {
            video.Pause();
        }
        if (video.isPaused) {
            Canvas.transform.position = Vector3.Lerp(Canvas.transform.position, new Vector3(Canvas.transform.position.x, 7, Canvas.transform.position.z), Time.deltaTime * 0.2f);
        }
    }
}
