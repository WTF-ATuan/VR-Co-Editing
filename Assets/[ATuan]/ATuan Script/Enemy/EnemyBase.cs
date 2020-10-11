using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public LevelSet level;
    public abstract void Onhit(BulletData bulletData);
    public abstract void OnPass();

}
