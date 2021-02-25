using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : ComponentSystem {
    private BulletData _bulletData;
    public override void OnStart()
    {
        _bulletData = GetComponent<BulletData>();
        gameObject.name = _bulletData.name;
        _bulletData.bubbleRig = GetComponent<Rigidbody>();
        Destroy(gameObject , 5f);
    }

    public override void OnUpdate()
    {
        _bulletData.bubbleRig.velocity = _bulletData.direction * _bulletData.speed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            _bulletData.isHit = true;
        }

        JudgeData();
    }

    private void JudgeData()
    {
        if(_bulletData.isHit)
            PlaySound(_bulletData.hitSound);
    }

    private void PlaySound(SoundFile file)
    {
        ScenceData.Data.soundManager.PlaySound(file);
    }
}
