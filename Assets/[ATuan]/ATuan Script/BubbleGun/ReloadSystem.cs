using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSystem : MonoBehaviour
{
    private BulletSet CurrentBulletSet => ScenceData.Data.currentBulletSet;
    public GunData gunData;
    [SerializeField] private BulletData[] bulletData;
    [SerializeField] private int currentBulletCount;

    public void Start()
    {
        bulletData = new BulletData[]
        {
            CurrentBulletSet.bullets[CurrentBulletSet.bullets.Count - 1],
            CurrentBulletSet.bullets[0],
            CurrentBulletSet.bullets[1]
        };
        currentBulletCount = 1;
        SetBulletData(bulletData);
        UpdateEvent.AddUpdate(OnUpdate);
    }

    public void OnUpdate()
    {
        GetBulletData(bulletData);
        if (gunData.needReload)
        {
            currentBulletCount = gunData.currentBulletCount;
            TrackGunData(CurrentBulletSet.bullets);
        }
    }

    public void TrackGunData(List<BulletData> bullets)
    {
        if (currentBulletCount > bullets.Count - 1)
            currentBulletCount = 0;
        if (currentBulletCount == 0)
            bulletData[0] = bullets[bullets.Count - 1];
        else
            bulletData[0] = bullets[currentBulletCount - 1];
        bulletData[1] = CurrentBulletSet.bullets[currentBulletCount];
        if (currentBulletCount == bullets.Count - 1)
            bulletData[2] = bullets[0];
        else
            bulletData[2] = bullets[currentBulletCount + 1];
        gunData.needReload = false;
        SetBulletData(bulletData);
    }

    public void GetBulletData(BulletData[] bulletDatas)
    {
        bulletDatas[0] = gunData.previousBullet;
        bulletDatas[1] = gunData.currentBullet;
        bulletDatas[2] = gunData.nextBullet;
    }

    public void SetBulletData(BulletData[] bulletDatas)
    {
        gunData.previousBullet = bulletDatas[0];
        gunData.currentBullet = bulletDatas[1];
        gunData.nextBullet = bulletDatas[2];
        gunData.currentBulletCount = currentBulletCount;
    }
}