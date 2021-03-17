using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ComponentSystem {
    [SerializeField]public BulletData bulletData;
    public float speed;
   // public Vector3 direction;
    
    private Rigidbody _bubbleRig;
    public override void OnStart(){
        
        _bubbleRig = GetComponent<Rigidbody>();
        Destroy(gameObject , 5f);
    }

    public override void OnUpdate()
    {
        _bubbleRig.AddForce(transform.forward * speed);
    }
    
}
