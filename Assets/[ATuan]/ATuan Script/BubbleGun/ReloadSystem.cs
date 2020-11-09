using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSystem : MonoBehaviour
{
    public BulletSet CurrentBulletSet => ScenceData.Data.currentBulletSet;
    public GunData gunData;
    [SerializeField] private BulletData[] bulletDatas;
    [SerializeField] private int currentbulletCount;

    public void Start()
    {
        bulletDatas = new BulletData[]
        {
            CurrentBulletSet.bullets[CurrentBulletSet.bullets.Count - 1],
            CurrentBulletSet.bullets[0],
            CurrentBulletSet.bullets[1]
        };
        currentbulletCount = 1;
        SetBulletData(bulletDatas);
        UpdateEvent.AddUpdate(OnUpdate);
    }

    public void OnUpdate()
    {
        GetBulletData(bulletDatas);
        if (gunData.needReload)
        {
            currentbulletCount = gunData.currentBulletCount;
            TrackGunData(CurrentBulletSet.bullets);
        }
    }

    public void TrackGunData(List<BulletData> bullets)
    {
        if (currentbulletCount > bullets.Count - 1)
            currentbulletCount = 0;
        if (currentbulletCount == 0)
            bulletDatas[0] = bullets[bullets.Count - 1];
        else
            bulletDatas[0] = bullets[currentbulletCount - 1];
        bulletDatas[1] = CurrentBulletSet.bullets[currentbulletCount];
        if (currentbulletCount == bullets.Count - 1)
            bulletDatas[2] = bullets[0];
        else
            bulletDatas[2] = bullets[currentbulletCount + 1];
        gunData.needReload = false;
        SetBulletData(bulletDatas);
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
        gunData.currentBulletCount = currentbulletCount;
    }
}