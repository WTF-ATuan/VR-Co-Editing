using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name != null) {
            IsPassing();
            Debug.Log(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
    private void IsPassing() {
        
    
    }
}
