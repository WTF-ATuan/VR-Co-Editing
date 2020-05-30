using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigger : MonoBehaviour {

    public string AnserOfStr;
    public GameObject AnserOfObj;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject != null) {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == AnserOfStr || other.gameObject.name == AnserOfObj.name) {
                IsPassing();
            } else {
                IsFall();
            }
            Destroy(other.gameObject);
        }
    }
    private void IsPassing() {
        Debug.Log("Good Job");
    
    }
    private void IsFall() {
        Debug.Log("Not the Same Obj");
          
    }
}
