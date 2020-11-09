using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSystem : ComponentSystem
{
    public BulletSet CurrentBulletSet => ScenceData.Data.currentBulletSet;
    public GunData gunData;
    [SerializeField] private BulletData[] bulletDatas;
    [SerializeField] private int currentbulletCount;

    public override void OnStart()
    {
        bulletDatas = new BulletData[]
        {
            CurrentBulletSet.bullets[0],
            CurrentBulletSet.bullets[1],
            CurrentBulletSet.bullets[2]
        };
        SetBulletData(bulletDatas);
        currentbulletCount = bulletDatas.Length + 1;
        UpdateEvent.AddUpdate(TrackGunData);
    }
    
    public void TrackGunData()
    {
        //偵測子彈是否為null 
        // if (true) 先拿取前一個子彈,並把前一個子彈射為null
        // 如果前一個子彈也是空的 再去bulletset裡面拿後面的子彈
        GetBulletData(bulletDatas);
        if (currentbulletCount > bulletDatas.Length)
            currentbulletCount = 0;
        for (int i = 0; i < bulletDatas.Length; i++)
        {
            if (bulletDatas[i] == null)
            {
                if (bulletDatas[i - 1] != null && i > 0)
                {
                    bulletDatas[i] = bulletDatas[i - 1];
                    bulletDatas[i - 1] = null;
                    SetBulletData(bulletDatas);
                }
                else
                {
                    bulletDatas[i] = CurrentBulletSet.bullets[currentbulletCount];
                    currentbulletCount += 1;
                    SetBulletData(bulletDatas);
                }
            }
        }
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
    }
}