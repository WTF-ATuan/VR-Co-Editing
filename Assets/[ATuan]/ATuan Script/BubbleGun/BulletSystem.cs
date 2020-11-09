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
    }

    public override void OnUpdate()
    {
        bulletData.bubbleRig.velocity = bulletData.direction * bulletData.Speed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            bulletData.isHit = true;
        }

        JugeData();
    }

    private void JugeData()
    {
        if(bulletData.isHit)
            PlaySound(bulletData.HitSound);
        //Destroy(gameObject);
    }

    private void PlaySound(SoundFile file)
    {
        ScenceData.Data.soundManager.PlaySound(file);
    }
}
