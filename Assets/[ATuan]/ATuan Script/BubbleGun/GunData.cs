using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GunData : MonoBehaviour
{
    public BulletData previousBullet;
    public BulletData currentBullet;
    public BulletData nextBullet;
    public int currentBulletCount;
    //public Animator GunAni;
    //public GameObject HitEffect;
    public Transform BarrelPivot;
    public float FireColdownTime;
    public float ChangingBulletTime;
    public SoundFile FireSound;
    public bool needReload;
}
