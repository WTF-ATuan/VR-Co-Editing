using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSet : MonoBehaviour
{
    public GameObject Boat;
    public Rigidbody BoatRig;
    public float Speed;
    public void Update() {
        BoatRig.velocity = new Vector3(0, 0, Speed);

    }

}
