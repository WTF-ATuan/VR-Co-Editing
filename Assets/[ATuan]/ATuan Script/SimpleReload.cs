using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleReload : MonoBehaviour
{
    [SerializeField] private GameObject OnReloadMagzine;
    public static bool OnReload = false;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Magzine") {
            OnReloadMagzine.SetActive(true);
            OnReload = true;
            Destroy(other.gameObject);
        }

    }
}
