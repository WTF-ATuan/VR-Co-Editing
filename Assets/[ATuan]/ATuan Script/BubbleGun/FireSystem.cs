using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MineData;
using System;

//負責生出子彈 以及變更子彈 
public class FireSystem : ComponentSystem {
    public GunData gunData;
    private Timer timer;
    public void Start()
    {
        timer = new Timer(gunData.ColdDownTime);
    }
    public override void OnUpdate()
    {
        FireTrigger();
        SnapTurnTrigger();
        timer.Tick(Time.fixedDeltaTime);
    }

    public void SnapTurnTrigger()
    {

    }

    public void FireTrigger()
    {
        if (InputData.instance.FireButton.active)
        {
            if (timer.IsTimerEnd)
            {
                OpenFire(gunData);
                timer.RestTimer();
            }
        }
    }
    public void OpenFire(GunData data)
    {
        Instantiate(data.currentBullet.gameObject, data.BarrelPivot.position, data.currentBullet.gameObject.transform.rotation);
        

    }
}
