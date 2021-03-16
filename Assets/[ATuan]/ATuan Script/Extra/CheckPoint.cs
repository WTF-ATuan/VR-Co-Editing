using System;
using UnityEngine;

namespace ATuan_Script.Extra{
	public class CheckPoint : MonoBehaviour{
		public bool levelControl;
		public Vector3 needRotate;
		public Transform needMovePos;
		public bool pass;

		private void OnTriggerEnter(Collider other){
			if(!levelControl && !pass && other.CompareTag("Player")){
				CheckPointManager.instance.PassLevel();
				pass = true;
			}
		
		}
	}
}