using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class StageTeachManager : MonoBehaviour
{
    [SerializeField] private List<TeleportPoint> teleportPoints = new List<TeleportPoint>(); 
    [SerializeField] private Teleport teleportBehaviour;
    [SerializeField] private ViveInput PlayerInput;

    [SerializeField] private GameObject[] TeachStageBubble;

    [SerializeField] private List<SetTrigger> TeachTrigger = new List<SetTrigger>();

    private int TeachTriggerCount;
    private bool IsOnLoad = false;
    public bool PassingTeachStage = false;
    private void Start() {
        TeachTriggerCount = TeachTrigger.Count;
    }
    private void Update()
    {
        StageTeach();
    }
    public void StageTeach() {
        //set trigger  要把set trigger的gameobject生出來 , 加上新的compoet  (可以做成方法 , 會需要一個gameobject的List)
        //順序
        //setTrigger 並生成(等prefab)

        //setBullet
        if (!IsOnLoad) {
            PlayerInput.fire.SetBullet(TeachStageBubble);
            IsOnLoad = true;
            PlayerInput.fire.IndexOfBullet = TeachStageBubble.Length;
        }
        //判定子彈是否射到
        for (int i = 0; i < TeachTrigger.Count; i++) {
            if (TeachTrigger[i].Pass) {
                PlayerInput.fire.RemoveBullet(TeachTrigger[i].PassObjcet);
                TeachTriggerCount -= 1;
                if (TeachTriggerCount <= 0 || PlayerInput.fire.Magazine.Count <= 0) {
                    PassingTeachStage = true;
                    Debug.Log("Passing TeachStage");
                }

            }
        }
            if(PassingTeachStage)
            SceneManager.LoadScene(1);
    }
}
