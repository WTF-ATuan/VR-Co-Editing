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
                ChangeImage(Obj);
                IsPassing(Obj);
            } else {
                IsFall();
            }
        }
    }
    public void ChangeImage(GameObject obj) {
        // 被射到的時候 要直接生一顆子彈在上面;
        Rigidbody AnserObjRig = Instantiate(obj, transform.position, obj.transform.rotation).GetComponent<Rigidbody>();
        Destroy(AnserObjRig);
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
