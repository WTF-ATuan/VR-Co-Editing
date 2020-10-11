using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSystem : ComponentSystem {
    public BulletData bulletData;
    public override void OnStart()
    {
        bulletData.bubbleData = GetComponent<BubbleData>();
        bulletData.bubbleData.bubbleRig = GetComponent<Rigidbody>();
        bulletData.bubbleData.isFire = true;
        bulletData.bubbleData.bubbleRig.velocity = Vector3.forward * bulletData.bubbleData.Speed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            bulletData.bubbleData.isHit = true;
        }
        JudgeData(collision.gameObject);
    }
    public void JudgeData(GameObject obj) {
        if (bulletData.bubbleData.isHit) {
            EnemyBase enemyBase = obj.GetComponent<EnemyBase>() ?? null;
            enemyBase.Onhit(bulletData);
        }
    }
}
