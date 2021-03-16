using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Level : MonoBehaviour{
	[SerializeField] private BulletData bulletData;
	[SerializeField] private GameObject passWordObject;
	public SoundFile goodSound;
	public bool isPass;
	

	public void OnTriggerEnter(Collider other){
		var otherBullet = other.GetComponent<BulletData>();
		if(otherBullet == bulletData){
			isPass = true;
			passWordObject.SetActive(true);
			ScenceData.Data.soundManager.PlaySound(goodSound);
		}
	}
	
}