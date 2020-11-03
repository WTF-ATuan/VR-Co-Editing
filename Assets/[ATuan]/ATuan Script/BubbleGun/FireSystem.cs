using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MineData;
using System;

//負責生出子彈 以及變更子彈 
public class FireSystem : ComponentSystem
{
    public GunData gunData;
    public Timer FireTImer;
    public Timer ChangingBulletTimer;
    public DataEvent<InputData> InputEvent;
    public BubbleGunUI gunUI;
    public override void OnStart()
    {
        FireTImer = new Timer(gunData.FireColdownTime);
        ChangingBulletTimer = new Timer(gunData.ChangingBulletTime);
        gunUI.Initialize(gunData);
        InputAction();
    }
    public void InputAction()
    {
        InputEvent.AddListener(SnapTurnTrigger);
        InputEvent.AddListener(FireTrigger);
    }
    public override void OnUpdate()
    {
        InputEvent.Invoke(InputData.instance);
        FireTImer.Tick(Time.fixedDeltaTime);
        ChangingBulletTimer.Tick(Time.fixedDeltaTime);
    }
    public void SnapTurnTrigger(InputData input)
    {
        if (input.SnapTurnLeft.active)
        {
            if (ChangingBulletTimer.IsTimerEnd)
            {
                ChangeBulletMinus(gunData);
                ChangingBulletTimer.RestTimer();
            }
        }
        if (input.SnapTurnRight.active)
        {
            if (ChangingBulletTimer.IsTimerEnd)
            {
                ChangeBulletPlus(gunData);
                ChangingBulletTimer.RestTimer();
            }
        }
        gunUI.ChangingMesh();
    }
    public void FireTrigger(InputData input)
    {
        if (input.FireButton.active)
        {
            if (FireTImer.IsTimerEnd)
            {
                OpenFire(gunData);
                FireTImer.RestTimer();
            }
        }
        gunUI.ChangingMesh();
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
