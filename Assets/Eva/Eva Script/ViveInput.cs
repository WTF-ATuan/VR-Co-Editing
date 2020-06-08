using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;




public class ViveInput : MonoBehaviour
{
    private Interactable interactable;

    public SteamVR_Action_Boolean GripFireAction;
    public SteamVR_Action_Boolean GrapPinchAction;
    public SteamVR_Action_Boolean SnapTurnLeft = SteamVR_Input.GetBooleanAction("TurnLeft");
    public SteamVR_Action_Boolean SnapTurnRight = SteamVR_Input.GetBooleanAction("TurnRight");
    public SteamVR_Action_Boolean IsGrapingGun;
    //public SteamVR_Action_Boolean snapRightAction = SteamVR_Input.GetBooleanAction("SnapTurnRight");

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    private void FixedUpdate()
    {
        InputOfVRSet();
    }

    public void InputOfVRSet()
    {
        //開槍Input
        if (GripFireAction.GetLastStateDown(SteamVR_Input_Sources.RightHand)) //讀取FireActicon GrapGrip值  
        {
            //OpenFIre();
            Debug.Log("OpenFIreVRInput");
            Fire.fireManager.OpenFIre();

        }
        //拿取物件Input
        if (GrapPinchAction.GetLastStateDown(SteamVR_Input_Sources.Any)) //讀取GrapPinchAction GrapPinch值  
        {

            Debug.Log("GrapPinchActionVRInput");

        }

        //搖桿左
        if (SnapTurnLeft.GetLastStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("TurnLeftActionVRInput");
            Fire.fireManager.ChangeBullectMinus();

        }

        //搖桿右
        if (SnapTurnRight.GetLastStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("TurnRightActionVRInput");
            Fire.fireManager.ChangeBullectPlus();

        }

    }
}