using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReloadSystem : MonoBehaviour{
	public BulletSet currentBulletSet;
	public GunData gunData;
	[SerializeField] private Bullet[] bulletData;
	[SerializeField] private int currentBulletCount;

	public void Start(){
		UpdateEvent.AddUpdate(OnUpdate);
	}

	public void LoadBullet(BulletSet bulletSet){
		currentBulletSet = bulletSet;
		bulletData = new[]{
			currentBulletSet.bullets[currentBulletSet.bullets.Count - 1],
			currentBulletSet.bullets[0],
			currentBulletSet.bullets[1]
		};
		currentBulletCount = 1;
		SetBulletData(bulletData);

	}

	private void OnUpdate(){
		GetBulletData(bulletData);
		if(gunData.needReload){
			currentBulletCount = gunData.currentBulletCount;
			TrackGunData(currentBulletSet.bullets);
		}
	}

	private void TrackGunData(List<Bullet> bullets){
		if(currentBulletCount > bullets.Count - 1)
			currentBulletCount = 0;
		if(currentBulletCount == 0)
			bulletData[0] = bullets[bullets.Count - 1];
		else
			bulletData[0] = bullets[currentBulletCount - 1];
		bulletData[1] = currentBulletSet.bullets[currentBulletCount];
		if(currentBulletCount == bullets.Count - 1)
			bulletData[2] = bullets[0];
		else
			bulletData[2] = bullets[currentBulletCount + 1];
		gunData.needReload = false;
		SetBulletData(bulletData);
	}

	private void GetBulletData(Bullet[] bullet){
		bullet[0] = gunData.previousBullet;
		bullet[1] = gunData.currentBullet;
		bullet[2] = gunData.nextBullet;
	}

	private void SetBulletData(Bullet[] bullet){
		gunData.previousBullet = bullet[0];
		gunData.currentBullet = bullet[1];
		gunData.nextBullet = bullet[2];
		gunData.currentBulletCount = currentBulletCount;
	}
}