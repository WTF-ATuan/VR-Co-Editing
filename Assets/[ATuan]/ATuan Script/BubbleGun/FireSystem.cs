using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : ComponentSystem
{
    public GunData gunData;
    private Timer FireTimer;
    private Timer ChangingBulletTimer;
    private DataEvent<InputData> InputEvent;
    public BubbleGunUI gunUI;

    public override void OnStart()
    {
        FireTimer = new Timer(gunData.FireColdownTime);
        ChangingBulletTimer = new Timer(gunData.ChangingBulletTime);
        gunUI.Initialize(gunData);
        InputAction();
    }

    private void InputAction()
    {
        InputEvent = new DataEvent<InputData>();
        InputEvent.AddListener(SnapTurnTrigger);
        InputEvent.AddListener(FireTrigger);
    }

    public override void OnUpdate()
    {
        if(InputData.instance.HandObject != gameObject)
            return;
        InputEvent.Invoke(InputData.instance);
        FireTimer.Tick(Time.fixedDeltaTime);
        ChangingBulletTimer.Tick(Time.fixedDeltaTime);
    }

    private void SnapTurnTrigger(InputData input)
    {
        if (input.TurnLeftAction)
        {
            if (ChangingBulletTimer.IsTimerEnd)
            {
                ChangeBulletMinus(gunData);
                ChangingBulletTimer.RestTimer();
            }
        }

        if (input.TurnRightAction)
        {
            if (ChangingBulletTimer.IsTimerEnd)
            {
                ChangeBulletPlus(gunData);
                ChangingBulletTimer.RestTimer();
            }
        }

        gunUI.ChangingMesh();
    }

    private void FireTrigger(InputData input)
    {
        if (input.FireAction)
        {
            if (FireTimer.IsTimerEnd)
            {
                OpenFire(gunData);
                FireTimer.RestTimer();
            }
        }

        gunUI.ChangingMesh();
    }

    private void OpenFire(GunData data)
    {
        var bulletData = Instantiate(data.currentBullet.gameObject, data.BarrelPivot.position,
            data.currentBullet.transform.rotation).GetComponent<BulletData>();
        bulletData.direction = data.BarrelPivot.forward.normalized;
        data.currentBulletCount++;
        data.needReload = true;
        Haptic();
        PlaySound(gunData.FireSound);
    }

    private void ChangeBulletPlus(GunData data)
    {
        data.currentBulletCount++;
        data.needReload = true;
        PlaySound(data.currentBullet.soundFile);
    }

    private void ChangeBulletMinus(GunData data)
    {
        data.currentBulletCount--;
        data.needReload = true;
        PlaySound(data.currentBullet.soundFile);
    }

    private void PlaySound(SoundFile file)
    {
        ScenceData.Data.soundManager.PlaySound(file);
    }

    private void Haptic()
    {
        InputData.instance.Haptic(0.5f, InputData.instance.hand.handType, 75f);
    }
}