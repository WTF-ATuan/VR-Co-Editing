using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATuan_Script.Extra{
	public class CheckPointManager : SingletonMonoBehavior<CheckPointManager>{
		public List<CheckPoint> checkPoints;
		public int currentPoint;

		public void MoveToTarget(Transform currentTransform, float speed , GameObject ship = null){
			if(!(ship is null)) ship.transform.eulerAngles = checkPoints[currentPoint].needRotate;
			var lerpPosition = Vector3.Lerp(currentTransform.position, checkPoints[currentPoint].needMovePos.position,
				Time.deltaTime * speed);
			currentTransform.position = lerpPosition;
		}

		public void PassLevel(){
			currentPoint += 1;
		}
	}
}