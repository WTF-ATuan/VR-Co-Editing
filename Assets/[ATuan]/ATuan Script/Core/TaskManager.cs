using System;
using System.Collections.Generic;
using UnityEngine;

namespace Atuan_Script.Core{
	public class TaskManager : MonoBehaviour{
		public List<EnemyBase> allEnemy;
		public List<BulletSet> allBullets;

		[SerializeField] private ReloadSystem bulletReload;
		private ScenceData _scenceData;

		private void Awake(){
			bulletReload.currentBulletSet = allBullets[0];
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