using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : ComponentSystem {
    [SerializeField]private BulletData bulletData;
    public float speed;
    
    private Rigidbody _bubbleRig;
    public override void OnStart(){

        gameObject.name = bulletData.name;
        bulletData.bulletObject = gameObject;
        bulletData.speed = speed;
        _bubbleRig = GetComponent<Rigidbody>();
        Destroy(gameObject , 5f);
    }

    public override void OnUpdate()
    {
        _bubbleRig.velocity = bulletData.direction * bulletData.speed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            bulletData.isHit = true;
        }

        JudgeData();
    }

    private void JudgeData()
    {
        if(bulletData.isHit)
            PlaySound(bulletData.hitSound);
    }

    private void PlaySound(SoundFile file)
    {
        ScenceData.Data.soundManager.PlaySound(file);
    }
}
