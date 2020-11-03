using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Animator))]
public abstract class EnemyBase : MonoBehaviour
{
    public LevelSet levels;
    public BulletSet bullets;
    public float MoveSpeed;
    public abstract Transform TargetPosition
    {
        get;
    }
    public void Awake()
    {
        if (!levels)
            Debug.LogError("Level not set");
        if (!bullets)
            Debug.LogError("bullet not set");
    }
    public void FixedUpdate()
    {
        if (TargetPosition != null)
            MoveToTarget(TargetPosition.position);
    }
    public abstract void Onhit(BulletData bulletData);
    public abstract void OnPass();

    public void MoveToTarget(Vector3 targetPosition)
    {
        transform.Translate(targetPosition.normalized * MoveSpeed);
    }

}
