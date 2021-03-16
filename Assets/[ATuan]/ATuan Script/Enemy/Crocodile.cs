using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : EnemyBase
{
    [SerializeField] private EventSystem passEvent;
    private static readonly int IsDead = Animator.StringToHash("isDead");

    protected override void OnPass(){
        base.OnPass();
        EnemyAnimator.SetBool(IsDead, true);
    }
    
}