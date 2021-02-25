using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(LevelData))]
public class LevelSystem : MonoBehaviour{
	[SerializeField] private LevelData levelData;

	private void Start(){
		if(levelData != null)
			return;
		levelData = GetComponent<LevelData>();
	}

	public void OnTriggerEnter(Collider other){
		if(other.name == levelData.answerBullet.name){
			levelData.pass = true;
		}
		else
			levelData.miss = true;

		JudgeData();
	}
	
	private void JudgeData(){
		var mesh = GetComponent<MeshRenderer>();
		if(levelData.pass){
			// pass image come out
			mesh.material = levelData.passWordMat;
			// pass sound come out
			PlayerSound(levelData.goodSound);
			GetComponent<Collider>().enabled = false;
		}

		if(levelData.miss){
			PlayerSound(levelData.badSound);
		}
	}

	private void PlayerSound(SoundFile file){
		ScenceData.Data.soundManager.PlaySound(file);
	}
}