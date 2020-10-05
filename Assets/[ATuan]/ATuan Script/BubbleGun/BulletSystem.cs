using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : ComponentSystem {
    public BubbleData bubbleData;

    public override void OnStart()
    {
        bubbleData = GetComponent<BubbleData>();
        bubbleData.bubbleRig = GetComponent<Rigidbody>();
        bubbleData.isFire = true;
        bubbleData.bubbleRig.velocity = Vector3.forward * bubbleData.Speed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            bubbleData.isHit = true;
        }
        JudgeData();
    }
    public void JudgeData() {
        if (bubbleData.isHit) {
            
        }
    }
}
