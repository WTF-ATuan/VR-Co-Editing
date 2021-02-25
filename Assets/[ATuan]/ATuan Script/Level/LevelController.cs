using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour{
	public bool Passing => IsPassLevel();
	public LevelSet levelSet;

	private bool IsPassLevel(){
		var isPass = false;
		foreach(var level in levelSet.levelData){
			var mesh = level.levelObj.GetComponent<MeshRenderer>();
			if(level.pass){
				ScenceData.Data.soundManager.PlaySound(levelSet.goodSound);
				mesh.material = levelSet.passMat;
				level.passWordObj.SetActive(true);
				level.levelObj.GetComponent<Collider>().enabled = false;
			}

			if(level.miss){
				ScenceData.Data.soundManager.PlaySound(levelSet.badSound);
				mesh.material = levelSet.errorMat;
				StartCoroutine(DelayChangeMesh(1f, mesh, levelSet.startMat));
			}

			if(!level.pass){
				isPass = true;
			}
		}

		return isPass;
	}

	private IEnumerator DelayChangeMesh(float delaySecond, Renderer mesh, Material changeMat){
		yield return new WaitForSeconds(delaySecond);
		mesh.material = changeMat;
	}
}