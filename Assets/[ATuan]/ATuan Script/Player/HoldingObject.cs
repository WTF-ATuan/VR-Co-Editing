using System;
using UnityEngine;
using Valve.VR;

public class HoldingObject : MonoBehaviour{
	private const SteamVR_Input_Sources HandSources = SteamVR_Input_Sources.RightHand;


	public Rigidbody holdingObject;
	

	private void FixedUpdate(){
		Holding();
	}
	
	private void Holding(){
		var holdingObjectTransform = holdingObject.transform;
		var thisTransform = transform;
		holdingObject.velocity = (thisTransform.position - holdingObjectTransform.position) / Time.fixedDeltaTime;

		holdingObject.maxAngularVelocity = 20;

		var deltaRot = thisTransform.rotation * Quaternion.Inverse(holdingObjectTransform.rotation);
		var eulerRot = new Vector3(Mathf.DeltaAngle(0, deltaRot.eulerAngles.x),
			Mathf.DeltaAngle(0, deltaRot.eulerAngles.y), Mathf.DeltaAngle(0, deltaRot.eulerAngles.z));
		eulerRot *= 0.95f;
		eulerRot *= Mathf.Deg2Rad;
		holdingObject.angularVelocity = eulerRot / Time.fixedDeltaTime;
	}
}