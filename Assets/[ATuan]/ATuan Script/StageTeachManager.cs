using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class StageTeachManager : SingletonMonoBehavior<StageTeachManager>
{

    [Header("Importing Input")]
    [SerializeField] private ViveInput PlayerInput;
    [SerializeField] private GameObject[] TeachStageBubble;
    [SerializeField] private List<SetTrigger> TeachTrigger = new List<SetTrigger>();
    [SerializeField] private GameObject AnserOfTech;
    [SerializeField] private GameObject FirstWall;
    [SerializeField] private SteamVR_LoadLevel ScenceChanger;
    private bool IsOnLoad = false;

    [Header("UISetting")]
    [SerializeField] private Material[] UIMaterials ;
    [SerializeField] private GameObject OnchangeUIGameObject;
    private Renderer UIRenderer;

    [Header("SoundManager")]
    [SerializeField] private AudioSource[] WordChange;
    [SerializeField] private AudioSource TaiwanSound;
    [SerializeField] private AudioSource[] JapanSound;
    public AudioSource successSound, failSound;
    [Header("Debug")]
    public bool PassingTeachStage = false;
    [Header("Teleport")]
    public GameObject TelePortFuntion;
    private void Start()
    {
        TelePortFuntion.SetActive(false);
        ScenceChanger.enabled = false;
        UIRenderer = OnchangeUIGameObject.GetComponent<Renderer>();
    }
    private void Update()
    {
        if (PassingTeachStage)
        {
            Invoke("PassTeachStage", 3f);
        }
        StageTeach();
    }
    public void StageTeach()
    {
        //順序
        //setBullet
        if (!IsOnLoad && SimpleReload.OnReload)
        {
            Debug.Log("Load");
            PlayerInput.fire.SetBullet(TeachStageBubble);
            PlayerInput.fire.animator.SetTrigger("OnChangeBullet");
            IsOnLoad = true;
            PlayerInput.fire.IndexOfBullet = 0;
        }
        //判定子彈是否射到
        for (int i = 0; i < TeachTrigger.Count; i++)
        {
            if (TeachTrigger[i].Pass)
            {
                PlayerInput.fire.RemoveBullet(TeachTrigger[i].AnserObject.name);
                SphereCollider collider = TeachTrigger[i].gameObject.GetComponent<SphereCollider>();
                Destroy(collider);
            }
        }
        //檢查triggers是否都被擊中 
        bool cheak = true;
        foreach (SetTrigger triggers in TeachTrigger)
        {
            if (!triggers.Pass)
            {
                cheak = false;
                break;
            }
        }
        if (cheak)
        {
            AnserOfTech.SetActive(true);
            PassingTeachStage = true;
        }
        if (SimpleReload.OnReload)
        {
            //牆壁往下
            FirstWall.transform.position = Vector3.Lerp(FirstWall.transform.position, new Vector3(FirstWall.transform.position.x, -3, FirstWall.transform.position.z), Time.deltaTime * 0.2f);
            InvokeRepeating("TaiwanSoundPlay",2f,3 );
            SoundPlay();
            //變更UI圖 
            MaterialChange();
        }
    }
    void SoundPlay() {
        JapanSound[PlayerInput.fire.IndexOfBullet].Play();
    }
    void TaiwanSoundPlay() {
        TaiwanSound.Play();
    }
    void PassTeachStage()
    {
        ScenceChanger.enabled = true;
        Destroy(this);
    }
    public void MaterialChange()
    {
         JapanSound[PlayerInput.fire.IndexOfBullet].Play();
         UIRenderer.material = UIMaterials[PlayerInput.fire.IndexOfBullet];
    }
}
