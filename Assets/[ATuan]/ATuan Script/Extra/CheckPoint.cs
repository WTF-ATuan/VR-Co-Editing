using System;
using UnityEngine;

namespace ATuan_Script.Extra{
	public class CheckPoint : MonoBehaviour{
		public bool levelControl;
		public Vector3 needRotate;
		public Transform needMovePos;

		private void OnTriggerEnter(Collider other){
			if(!levelControl)
				CheckPointManager.instance.PassLevel();
		}
	}
}