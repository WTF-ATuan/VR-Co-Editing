using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

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
        InputEvent = new DataEvent<InputData>();
        InputEvent.AddListener(SnapTurnTrigger);
        InputEvent.AddListener(FireTrigger);
    }

    public override void OnUpdate()
    {
        if(InputData.instance.HandObjcet != gameObject)
            return;
        InputEvent.Invoke(InputData.instance);
        FireTImer.Tick(Time.fixedDeltaTime);
        ChangingBulletTimer.Tick(Time.fixedDeltaTime);
    }

    public void SnapTurnTrigger(InputData input)
    {
        if (input.SnapTurnLeft.GetLastStateDown(SteamVR_Input_Sources.Any))
        {
            if (ChangingBulletTimer.IsTimerEnd)
            {
                ChangeBulletMinus(gunData);
                ChangingBulletTimer.RestTimer();
            }
        }

        if (input.SnapTurnRight.GetLastStateDown(SteamVR_Input_Sources.Any))
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
        if (input.FireButton.GetLastStateDown(SteamVR_Input_Sources.Any))
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
        BulletData bulletData = Instantiate(data.currentBullet.gameObject, data.BarrelPivot.position,
            data.currentBullet.transform.rotation).GetComponent<BulletData>();
        bulletData.direction = gunData.gameObject.transform.eulerAngles.normalized;
        data.currentBulletCount++;
        data.needReload = true;
        PlaySound(gunData.FireSound);
    }

    public void ChangeBulletPlus(GunData data)
    {
        data.currentBulletCount++;
        data.needReload = true;
        PlaySound(data.currentBullet.soundFile);
    }

    public void ChangeBulletMinus(GunData data)
    {
        data.currentBulletCount--;
        data.needReload = true;
        PlaySound(data.currentBullet.soundFile);
    }

    private void PlaySound(SoundFile file)
    {
        ScenceData.Data.soundManager.PlaySound(file);
    }
}