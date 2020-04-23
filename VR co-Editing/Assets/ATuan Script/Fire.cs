using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Fire : MonoBehaviour
{
    public SteamVR_Action_Boolean FireAction;
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform BarrelPivot;
    public GameObject MuzzlerLash;


    private Animator animator;
    private Interactable interactable;
    void Start()
    {
        animator = GetComponent<Animator>();
        MuzzlerLash.SetActive(false);
        interactable.GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (interactable.attachedToHand != null) {

        //    SteamVR_Input_Sources source = interactable.attachedToHand.handType;

        //    if (FireAction[source].stateDown) {
        //        OpenFIre();
        //    }
            
        //}


        if (Input.GetMouseButtonDown(0)) {
            OpenFIre();
        }

    }
    void OpenFIre() {
        Debug.Log("Fireing");
        Rigidbody bulletRb = Instantiate(Bullet, BarrelPivot.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.velocity = BarrelPivot.forward*BulletSpeed;
        MuzzlerLash.SetActive(true);
    
    }
}
