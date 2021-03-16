using UnityEngine;

namespace ATuan_Script.Enemy{
	public class Man : EnemyBase{

		private readonly int _pass = Animator.StringToHash("pass");
		protected override void OnPass(){
			base.OnPass();
			EnemyAnimator.SetTrigger(_pass);
		}

		public void OnAnimationOver(){
			gameObject.SetActive(false);
		}

		public void CloseLevel(){
			levelController.gameObject.SetActive(false);
		}
	}
}