using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : ComponentSystem{
	public GunData gunData;
	private Timer _fireTimer;
	private Timer _changingBulletTimer;
	public BubbleGunUI gunUI;

	public override void OnStart(){
		_fireTimer = new Timer(gunData.fireColdDownTime);
		_changingBulletTimer = new Timer(gunData.changingBulletTime);
		gunUI.Initialize(gunData);
	}
	
	public override void OnUpdate(){
		_fireTimer.Tick(Time.fixedDeltaTime);
		_changingBulletTimer.Tick(Time.fixedDeltaTime);
	}
	
	public void BulletChangeLeft(){
		if(_changingBulletTimer.IsTimerEnd){
			ChangeBulletMinus(gunData);
			_changingBulletTimer.RestTimer();
		}
		gunUI.ChangingMesh();
	}
	public void BulletChangeRight(){
		if(_changingBulletTimer.IsTimerEnd){
			ChangeBulletPlus(gunData);
			_changingBulletTimer.RestTimer();
		}
		gunUI.ChangingMesh();
	}
	

	public void FireTrigger(){
		if(_fireTimer.IsTimerEnd){
			OpenFire(gunData);
			_fireTimer.RestTimer();
		}

		gunUI.ChangingMesh();
	}

	private void OpenFire(GunData data){
		var bulletData = Instantiate(data.currentBullet.gameObject, data.barrelPivot.position,
			data.currentBullet.transform.rotation).GetComponent<BulletData>();
		bulletData.direction = data.barrelPivot.forward.normalized;
		bulletData.isFire = true;
		data.currentBulletCount++;
		data.needReload = true;
		PlaySound(gunData.fireSound);
	}

	private void ChangeBulletPlus(GunData data){
		data.currentBulletCount++;
		data.needReload = true;
		PlaySound(data.currentBullet.soundFile);
	}

	private void ChangeBulletMinus(GunData data){
		data.currentBulletCount--;
		data.needReload = true;
		PlaySound(data.currentBullet.soundFile);
	}

	private void PlaySound(SoundFile file){
		ScenceData.Data.soundManager.PlaySound(file);
	}
}