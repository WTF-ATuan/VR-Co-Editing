using System;
using System.Collections.Generic;
using UnityEngine;

namespace Atuan_Script.Core{
	public class TaskManager : MonoBehaviour{
		public List<EnemyBase> allEnemy;
		public List<BulletSet> allBullets;

		private ScenceData _scenceData;

		public void Initialize(ScenceData data){
			allEnemy = data.allEnemy;
			allBullets = data.allBullets;
			_scenceData = data;
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
			_scenceData.currentEnemy = allEnemy[GetNotPassIndex()];
			_scenceData.currentBulletSet = allBullets[GetNotPassIndex()];
		}
	}
}