using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : ComponentSystem{
	public GunData gunData;
	private Timer _fireTimer;
	private Timer _changingBulletTimer;
	public BubbleGunUI gunUI;

	[SerializeField]private LineRenderer line;
	[SerializeField] private Transform linePosition;

	public override void OnStart(){
		_fireTimer = new Timer(gunData.fireColdDownTime);
		_changingBulletTimer = new Timer(gunData.changingBulletTime);
		gunUI.Initialize(gunData);
		line.SetPositions(new[]{Vector3.zero, Vector3.zero});
	}

	public override void OnUpdate(){
		_fireTimer.Tick(Time.fixedDeltaTime);
		_changingBulletTimer.Tick(Time.fixedDeltaTime);
		if(HandInput.Input.PinchPress) FireTrigger();
		if(HandInput.Input.SnapLeft) BulletChangeLeft();
		if(HandInput.Input.SnapRight) BulletChangeRight();
		line.SetPosition(0 , linePosition.position);
		line.SetPosition(1 , linePosition.forward);
	}

	private void BulletChangeLeft(){
		if(_changingBulletTimer.IsTimerEnd){
			ChangeBulletMinus(gunData);
			_changingBulletTimer.RestTimer();
		}

		gunUI.ChangingMesh();
	}

	private void BulletChangeRight(){
		if(_changingBulletTimer.IsTimerEnd){
			ChangeBulletPlus(gunData);
			_changingBulletTimer.RestTimer();
		}

		gunUI.ChangingMesh();
	}


	private void FireTrigger(){
		if(_fireTimer.IsTimerEnd){
			OpenFire(gunData);
			_fireTimer.RestTimer();
		}

		gunUI.ChangingMesh();
	}

	private void OpenFire(GunData data){
		Instantiate(data.currentBullet.gameObject, data.barrelPivot.position,
			data.currentBullet.gameObject.transform.rotation);
		data.currentBullet.direction = data.barrelPivot.forward.normalized;
		data.currentBulletCount++;
		data.needReload = true;
		PlaySound(gunData.fireSound);
	}

	private void ChangeBulletPlus(GunData data){
		data.currentBulletCount++;
		data.needReload = true;
		PlaySound(data.currentBullet.bulletData.soundFile);
	}

	private void ChangeBulletMinus(GunData data){
		data.currentBulletCount--;
		data.needReload = true;
		PlaySound(data.currentBullet.bulletData.soundFile);
	}

	private void PlaySound(SoundFile file){
		ScenceData.Data.soundManager.PlaySound(file);
	}
}