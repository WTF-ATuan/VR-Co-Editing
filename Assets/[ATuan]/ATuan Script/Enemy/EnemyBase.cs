using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public LevelSet level;
    public void Awake()
    {
        if (!level)
            Debug.LogError("Level not set");
    }
    public abstract void Onhit(BulletData bulletData);
    public abstract void OnPass();

}
