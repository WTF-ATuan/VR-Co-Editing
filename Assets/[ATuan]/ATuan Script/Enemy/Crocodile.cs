using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : EnemyBase
{
    [SerializeField] private EventSystem onPassEvent;
    [SerializeField] private GameObject changingMeshObject;
    protected override Vector3 TargetPosition => ScenceData.Data.player.transform.position;

    protected override void OnHit()
    {
        
    }

    protected override void OnPass()
    {
        answerObject.SetActive(true);
        EnemyAnimator.SetBool("isDead", true);
        moveSpeed = 0;
    }

    protected override void OnFail()
    {
        moveSpeed = 0;
        
    }
}