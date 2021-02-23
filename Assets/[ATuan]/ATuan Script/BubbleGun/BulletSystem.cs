using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : ComponentSystem {
    private BulletData bulletData;
    public override void OnStart()
    {
        bulletData = GetComponent<BulletData>();
        gameObject.name = bulletData.name;
        bulletData.bubbleRig = GetComponent<Rigidbody>();
        Destroy(gameObject , 5f);
    }

    public override void OnUpdate()
    {
        bulletData.bubbleRig.velocity = bulletData.direction * bulletData.speed;
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

    //private void OnDestroy()
    //{
    //}
}
