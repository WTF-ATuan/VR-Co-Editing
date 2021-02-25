using System;
using UnityEngine;
using Valve.VR;

public class HoldingObject : MonoBehaviour{
	private const SteamVR_Input_Sources HandSources = SteamVR_Input_Sources.RightHand;


	public Rigidbody holdingObject;

	public FireSystem loadFire;
	

	private void FixedUpdate(){
		Holding();
		FireControl();
	}

	private void FireControl(){
		if(SteamVR_Actions.default_GrabPinch.GetStateDown(HandSources)){
			loadFire.FireTrigger();
		}

		if(SteamVR_Actions.default_SnapTurnLeft.GetStateDown(HandSources)){
			loadFire.BulletChangeLeft();
		}

		if(SteamVR_Actions.default_SnapTurnRight.GetStateDown(HandSources)){
			loadFire.BulletChangeRight();
		}
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