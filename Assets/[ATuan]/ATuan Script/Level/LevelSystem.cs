using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class LevelSystem : MonoBehaviour{
	[SerializeField] private LevelData levelData;
	[SerializeField] private GameObject passWordObject;

	private void Start(){
		levelData.levelObj = gameObject;
		levelData.passWordObj = passWordObject;
	}

	public void OnTriggerEnter(Collider other){
		if(other.name == levelData.answerBullet.name){
			levelData.pass = true;
		}
		else
			levelData.miss = true;
		
	}
	
}