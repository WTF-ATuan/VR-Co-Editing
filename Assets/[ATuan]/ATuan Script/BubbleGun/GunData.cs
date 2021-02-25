using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GunData : MonoBehaviour
{
    public BulletData previousBullet;
    public BulletData currentBullet;
    public BulletData nextBullet;
    public int currentBulletCount;
    public Transform barrelPivot;
    public float fireColdDownTime;
    public float changingBulletTime;
    public SoundFile fireSound;
    public bool needReload;
}
