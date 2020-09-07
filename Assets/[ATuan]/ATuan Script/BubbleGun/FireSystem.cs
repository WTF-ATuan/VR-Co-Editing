using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MineData;
using System;

//負責生出子彈 以及變更子彈 
public class FireSystem : ComponentSystem {
    public GunData gunData;
    private Timer FireTImer;
    private Timer ChangingBulletTimer;
    public override void OnStart()
    {
        FireTImer = new Timer(gunData.FireColdownTime);
        ChangingBulletTimer = new Timer(gunData.ChangingBulletTime);
    }
    public override void OnUpdate()
    {
        FireTrigger();
        SnapTurnTrigger();
        FireTImer.Tick(Time.fixedDeltaTime);
        ChangingBulletTimer.Tick(Time.fixedDeltaTime);
    }

    public void SnapTurnTrigger()
    {
        if (InputData.instance.SnapTurnLeft.active)
        {
            if (ChangingBulletTimer.IsTimerEnd)
            {
                ChangeBulletMinus(gunData);
                ChangingBulletTimer.RestTimer();
            }
        }
        if (InputData.instance.SnapTurnRight.active)
        {
            if (ChangingBulletTimer.IsTimerEnd)
            {
                ChangeBulletPlus(gunData);
                ChangingBulletTimer.RestTimer();
            }
        }
    }

    public void FireTrigger()
    {
        if (InputData.instance.FireButton.active)
        {
            if (FireTImer.IsTimerEnd)
            {
                OpenFire(gunData);
                FireTImer.RestTimer();
            }
        }
    }
    public void OpenFire(GunData data)
    {
        GameObject bullet = Instantiate(data.currentBullet.gameObject, data.BarrelPivot.position, data.currentBullet.gameObject.transform.rotation);
        bullet.name = data.name;
        data.currentBullet = null;

    }
    public void ChangeBulletPlus(GunData data)
    {
        data.previousBullet = data.currentBullet;
        data.currentBullet = data.nextBullet;
        data.nextBullet = null;
    }
    public void ChangeBulletMinus(GunData data)
    {
        data.nextBullet = data.currentBullet;
        data.currentBullet = data.previousBullet;
        data.previousBullet = null;
    }
}
