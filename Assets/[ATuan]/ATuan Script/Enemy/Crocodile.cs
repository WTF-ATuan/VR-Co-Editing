using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : EnemyBase
{
    public override Transform TargetPosition {
        get => ScenceData.Data.EndPoint;
    }

    public override void Onhit(BulletData bulletData)
    {

    }
    public override void OnPass()
    {
       
    }
}
