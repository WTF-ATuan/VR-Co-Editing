using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigger : MonoBehaviour {
    [SerializeField] private Fire fire;

    public string AnserOfStr;
    public GameObject AnserOfObj;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject != null) {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == AnserOfStr || other.gameObject.name == AnserOfObj.name) {
                GameObject Obj = other.gameObject;
                ChangeImage(Obj);
                IsPassing(Obj);
            } else {
                IsFall();
            }
            Destroy(other.gameObject);
        }
    }
    public void ChangeImage(GameObject Obj) {
        // 被射到的時候 要change gameobject 的貼圖 ;


    }
    public bool IsPassing(GameObject Obj) {
        fire.Magazine.RemoveAt(fire.IndexOfBullet);
        Debug.Log("Good Job");
        Destroy(this.gameObject);
        GameManager.instance.TeachTriggerCount -= 1 ;
        return true;
    
    }
    public void IsFall() {
        Debug.Log("Not the Same Obj");
          
    }
}
