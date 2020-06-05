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
                IsPassing(Obj);
            } else {
                IsFall();
            }
            Destroy(other.gameObject);
        }
    }
    public bool IsPassing(GameObject Obj) {
        fire.Magazine.RemoveAt(fire.IndexOfBullet);
        Debug.Log("Good Job");
        Destroy(this.gameObject);
        return true;
    
    }
    public void IsFall() {
        Debug.Log("Not the Same Obj");
          
    }
}
