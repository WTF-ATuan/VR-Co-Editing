using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Atuan_Script.Core;
using ATuan_Script.Extra;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Animator))]
public abstract class EnemyBase : MonoBehaviour{
	protected Animator EnemyAnimator;
	public LevelController levelController;
	public SoundFile titleSoundFile;
	public float repeatTime;
	public CheckPoint thisLevelPoint;

	public bool Pass => levelController.Passing;

	private void Awake(){
		StartCoroutine(TitleSound(repeatTime, titleSoundFile));
		EnemyAnimator = GetComponent<Animator>();
		levelController = GetComponentInChildren<LevelController>();
		UpdateEvent.AddUpdate(OnUpdate);
	}


	protected virtual void OnPass(){
		thisLevelPoint.levelControl = true;
		CheckPointManager.instance.PassLevel();
		TaskManager.instance.LoadTask();
	}


	protected virtual void OnUpdate(){
		PassTrack();
	}

	private void PassTrack(){
		if(levelController.Passing){
			OnPass();
		}
	}

	private IEnumerator TitleSound(float second, SoundFile file){
		if(levelController.Passing)
			yield break;
		yield return new WaitForSeconds(second);
		PlaySound(file);
		StartCoroutine(TitleSound(second, file));
	}

	private void PlaySound(SoundFile file){
		ScenceData.Data.soundManager.PlaySound(file);
	}
}