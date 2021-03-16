using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : EnemyBase
{
    [SerializeField] private EventSystem passEvent;
    private static readonly int IsDead = Animator.StringToHash("isDead");
    protected override Vector3 TargetPosition => ScenceData.Data.player.transform.position;

    protected override void OnHit()
    {
        
    }


    protected override void OnPass(){
        base.OnPass();
        EnemyAnimator.SetBool(IsDead, true);
        moveSpeed = 0;
    }

    protected override void OnFail()
    {
        moveSpeed = 0;
        
    }
}