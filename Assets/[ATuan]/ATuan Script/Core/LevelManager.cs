using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{
	private List<LevelSet> Levels;
	private List<BulletSet> Bullets;
	private ScenceData data;
	[HideInInspector] public BulletSet nextBullet;
	[HideInInspector] public BulletSet currentBullet;
	[HideInInspector] public LevelSet nextLevel;
	[HideInInspector] public LevelSet currentLevel;
	public int currentLevelNumber;


	public void Initialize(ScenceData scenceData){
		data = scenceData;
		Levels = scenceData.AllLevels;
		Bullets = scenceData.AllBullets;
		AwakeLevel();
		LevelLoad();
	}

	private void AwakeLevel(){
		if(Levels == null || Bullets == null)
			Debug.LogError("NotSetLevel or Bullet");
		currentLevelNumber = -1;
		if(currentLevel != null)
			currentLevelNumber++;
		if(nextLevel != null)
			currentLevelNumber++;
	}
//在變換關卡的時候可以跑這個funtion;
	private void LevelLoad(){
		bool thisLevelPass;
		if(currentLevel != null){
			LevelUpdate(currentLevel, out thisLevelPass);
			if(thisLevelPass){
				currentLevel = null;
				thisLevelPass = false;
			}
		}
		else{
			if(nextLevel != null){
				currentLevel = nextLevel;
				currentLevelNumber++;
				nextLevel = Levels[currentLevelNumber];
			}
			else
				Debug.LogError("MissingNextLevel");
		}
		BulletLoad();
		Debug.Log("LevelReady");
		SetLevelData();
	}

	private void SetLevelData(){
		data.currentLevel = currentLevel;
		data.currentBulletSet = currentBullet;
	}

	private void BulletLoad(){
		if(currentBullet != null)
			return;
		if(nextBullet != null){
			currentBullet = nextBullet;
			nextBullet = Bullets[currentLevelNumber];
		}
		else{
			Debug.Log("Missing Bullet");
		}
	}
	

	private void LevelUpdate(LevelSet currentLevel, out bool pass){
		bool isPass = true;
		foreach(var item in currentLevel.LevelDatas){
			if(item.pass)
				isPass = false;
		}

		if(isPass){
			currentLevel.OnPassing.Invoke(null);
			pass = true;
		}

		pass = false;
	}
}