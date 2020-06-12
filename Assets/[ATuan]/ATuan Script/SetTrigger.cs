using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigger : MonoBehaviour {

    public GameObject PassObjcet = null;
    public bool Pass = false;
    public GameObject AnserObject = null;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject != null) {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == PassObjcet.name) {
                GameObject Obj = other.gameObject;
                IsPassing(Obj);
            } else {
                IsFall();
            }
        }
    }
    public void ChangeImage() {
        // 被射到的時候 要change gameobject 的貼圖 ;
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        
    }
    public void IsPassing(GameObject Obj) {
        Debug.Log("Good Job");
        AnserObject = Obj;
        Pass = true; 
    }
    public void IsFall() {
        Debug.Log("Not the Same Obj");
          
    }
}
