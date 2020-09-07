using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MineData;
public class GunData : MonoBehaviour , IFireData {
    public BulletData previousBullet = null;
    public BulletData currentBullet = null;
    public BulletData nextBullet = null;
    public Animator GunAni;
    public GameObject HitEffect;
    public Transform BarrelPivot;
    public float FireColdownTime = 0f;
    public float ChangingBulletTime = 0f;
}
