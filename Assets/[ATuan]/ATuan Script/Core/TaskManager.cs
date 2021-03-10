using System.Collections.Generic;
using UnityEngine;

namespace Atuan_Script.Core{
	public class TaskManager : MonoBehaviour{
		public List<EnemyBase> allEnemy;
		public List<BulletSet> allBullets;

		public void Initialize(ScenceData data){
			allEnemy = data.allEnemy;
			allBullets = data.allBullets;
		}

		private int GetNotPassIndex(){
			for(var i = 0; i < allEnemy.Count; i++){
				if(!allEnemy[i].Pass) return i;
			}
			return 0;
		}
	}
}