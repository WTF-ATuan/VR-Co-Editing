using Atuan_Script.Core;
using ATuan_Script.Extra;
using UnityEngine;

namespace ATuan_Script.Enemy{
	public class Man : EnemyBase{

		private readonly int _pass = Animator.StringToHash("pass");
		protected override void OnPass(){
			EnemyAnimator.SetTrigger(_pass);
		}

		public void OnAnimationOver(){
			CheckPointManager.instance.PassLevel();
			TaskManager.instance.LoadTask();
			gameObject.SetActive(false);
		}

		public void CloseLevel(){
			levelController.gameObject.SetActive(false);
		}
	}
}