using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandInput : MonoBehaviour{
	public static HandInput Input;
	[SerializeField] private SteamVR_Action_Boolean firePinch;
	[SerializeField] private SteamVR_Action_Boolean snapLeft;
	[SerializeField] private SteamVR_Action_Boolean snapRight;

	public bool PinchPress => firePinch.GetLastStateDown(SteamVR_Input_Sources.Any);
	public bool SnapLeft => snapLeft.GetLastStateDown(SteamVR_Input_Sources.Any);
	public bool SnapRight => snapRight.GetLastStateDown(SteamVR_Input_Sources.Any);

	private void Awake(){
		Input = this;
	}
}