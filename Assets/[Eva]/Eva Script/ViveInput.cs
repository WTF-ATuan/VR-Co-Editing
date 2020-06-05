using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;




public class ViveInput : MonoBehaviour {

    [SerializeField] public Fire fire;
    [SerializeField] private Hand RightHand;
    [SerializeField] private Hand LeftHand;
    private bool IsGraping;

    public SteamVR_Action_Boolean GripFireAction;
    public SteamVR_Action_Boolean GrapPinchAction;
    public SteamVR_Action_Boolean SnapTurnLeft = SteamVR_Input.GetBooleanAction("TurnLeft");
    public SteamVR_Action_Boolean SnapTurnRight = SteamVR_Input.GetBooleanAction("TurnRight");
    public SteamVR_Action_Boolean IsGrapingGun;
    //public SteamVR_Action_Boolean snapRightAction = SteamVR_Input.GetBooleanAction("SnapTurnRight");

    private void FixedUpdate()
    {
        InputOfVRSet();
    }

    public void InputOfVRSet()
    {
        if (RightHand.ObjectIsAttached(fire.gameObject)) {
            IsGraping = true;
            if (IsGraping) {
               
            }
        }
        //開槍Input
        if (GripFireAction.GetLastStateDown(SteamVR_Input_Sources.RightHand) && RightHand.currentAttachedObject.tag == "LoudGun") //讀取FireActicon GrapGrip值  
        {
            //OpenFIre();
            fire.OpenFIre();
            Debug.Log("OpenFIreVRInput");
        }
        //拿取物件Input
        if (GrapPinchAction.GetLastStateDown(SteamVR_Input_Sources.Any)) //讀取GrapPinchAction GrapPinch值  
        {

            Debug.Log("GrapPinchActionVRInput");

        }

        //搖桿左
        if (SnapTurnLeft.GetLastStateDown(SteamVR_Input_Sources.RightHand) && RightHand.currentAttachedObject.tag == "LoudGun")
        {
            fire.ChangeBullectMinus();
            Debug.Log("TurnLeftActionVRInput");
         
        }

        //搖桿右
        if (SnapTurnRight.GetLastStateDown(SteamVR_Input_Sources.RightHand) && RightHand.currentAttachedObject.tag == "LoudGun")
        {
            fire.ChangeBullectPlus();
            Debug.Log("TurnRightActionVRInput");
          
        }

    }
}