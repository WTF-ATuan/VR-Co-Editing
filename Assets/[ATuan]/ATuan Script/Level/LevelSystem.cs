using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(LevelData))]
public class LevelSystem : MonoBehaviour{
	private LevelData _levelData;

	private void Start(){
		if(_levelData != null)
			return;
		_levelData = GetComponent<LevelData>();
	}

	public void OnTriggerEnter(Collider other){
		if(other.name == _levelData.answerBullet.name){
			_levelData.pass = true;
		}
		else
			_levelData.miss = true;

		JudgeData();
	}
	
	private void JudgeData(){
		var mesh = GetComponent<MeshRenderer>();
		if(_levelData.pass){
			// pass image come out
			mesh.material = _levelData.passWordMat;
			// pass sound come out
			PlayerSound(_levelData.goodSound);
			GetComponent<Collider>().enabled = false;
		}

		if(_levelData.miss){
			PlayerSound(_levelData.badSound);
		}
	}

	private void PlayerSound(SoundFile file){
		ScenceData.Data.soundManager.PlaySound(file);
	}
}