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

		private void Awake(){
			foreach(var enemy in allEnemy){
				enemy.gameObject.SetActive(false);
			}
			LoadTask();
		}

		public void LoadTask(){
			currentLevel++;
			bulletReload.LoadBullet(allBullets[currentLevel]);
			allEnemy[currentLevel].gameObject.SetActive(true);
		}

		private int GetNotPassIndex(){
			for(var i = 0; i < allEnemy.Count; i++){
				if(!allEnemy[i].Pass) return i;
			}
			return 0;
		}

		private void Update(){
			if(GetNotPassIndex() == 0){
				_scenceData.pass?.Invoke(null);
				Destroy(this);
			}
		}
	}
}