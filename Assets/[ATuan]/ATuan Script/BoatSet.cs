using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSet : MonoBehaviour
{
    public GameObject Boat;
    public Transform BoatPosition;
    public Rigidbody BoatRig;
    [SerializeField] private float Speed;
    [SerializeField] private float MaxDistance;
    public void Start() {
        BoatRig.velocity = new Vector3(0, 0, Speed);
    }
    public void Update() {
        RaycastHit hit;
        Ray BoatRay = new Ray(BoatPosition.position, Vector3.forward);
        //Debug.DrawRay(BoatPosition.position, Vector3.forward , Color.red , MaxDistance);
        if (Physics.Raycast(BoatRay, out hit, 50f)) {
            //Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "Trigger" && hit.distance < MaxDistance) {
                BoatRig.velocity = Vector3.zero;
               
            } else
                BoatRig.velocity = new Vector3(0, 0, Speed);

        } else
            BoatRig.velocity = new Vector3(0, 0, Speed);
    }

}
