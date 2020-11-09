using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : EnemyBase
{
    protected override Vector3 TargetPosition
    {
        get => ScenceData.Data.EndPoint.position;
    }

    protected override void Onhit()
    {
    }

    protected override void OnPass()
    {
        anserObject.SetActive(true);
        EnemyAnimator.SetBool("isdead", true);
    }

    protected override void OnFail()
    {
        
    }
}