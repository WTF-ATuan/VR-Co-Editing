using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigger : MonoBehaviour {

    public GameObject PassObjcet = null;
    public bool Pass = false;
    public string AnserOfStr;
    public GameObject AnserOfObj;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject != null) {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == AnserOfStr || other.gameObject.name == AnserOfObj.name) {
                GameObject Obj = other.gameObject;
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
    public void IsPassing(GameObject Obj) {
        Debug.Log("Good Job");
        ChangeImage(Obj);
        Pass = true;
        PassObjcet = Obj;
    }
    public void IsFall() {
        Debug.Log("Not the Same Obj");
          
    }
}
