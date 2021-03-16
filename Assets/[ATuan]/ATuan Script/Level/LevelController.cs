using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour{
	public bool Passing => IsPassLevel();
	public Level[] thisLevels;

	private void Start(){
		thisLevels = GetComponentsInChildren<Level>();
	}

	private bool IsPassLevel(){
		var isPass = true;
		foreach(var level in thisLevels){
			if(!level.isPass){
				isPass = false;
			}
		}
		return isPass;
	}
	
}