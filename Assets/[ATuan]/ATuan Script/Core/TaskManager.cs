using System;
using System.Collections.Generic;
using UnityEngine;

namespace Atuan_Script.Core{
	public class TaskManager : SingletonMonoBehavior<TaskManager>{
		public List<EnemyBase> allEnemy;
		public List<BulletSet> allBullets;

		[SerializeField] private ReloadSystem bulletReload;
		private ScenceData _scenceData;
		public int currentLevel;

		private void Start(){
			foreach(var enemy in allEnemy){
				enemy.gameObject.SetActive(false);
			}
			LoadTask();
		}

		public void LoadTask(){
			bulletReload.LoadBullet(allBullets[currentLevel]);
			allEnemy[currentLevel].gameObject.SetActive(true);
			currentLevel++;
		}
		
	}
}