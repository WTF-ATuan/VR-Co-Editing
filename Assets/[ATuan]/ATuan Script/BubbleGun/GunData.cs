using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GunData : MonoBehaviour
{
    public Bullet previousBullet;
    public Bullet currentBullet;
    public Bullet nextBullet;
    public int currentBulletCount;
    public Transform barrelPivot;
    public float fireColdDownTime;
    public float changingBulletTime;
    public SoundFile fireSound;
    public bool needReload;
}
