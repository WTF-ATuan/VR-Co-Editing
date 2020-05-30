using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;




public class ViveInput : MonoBehaviour
{

    public SteamVR_Action_Boolean GripFireAction;
    public SteamVR_Action_Boolean GrapPinchAction;
    public SteamVR_Action_Boolean SnapTurnLeft = SteamVR_Input.GetBooleanAction("TurnLeft");
    public SteamVR_Action_Boolean SnapTurnRight = SteamVR_Input.GetBooleanAction("TurnRight");
    public Fire GetFire;
    //public SteamVR_Action_Boolean snapRightAction = SteamVR_Input.GetBooleanAction("SnapTurnRight");
    public void Start()
    {
        GetFire = new Fire();   
    }

    public void Update()
    {

        InputOfVRSet();

    }


    public void InputOfVRSet()
    {
        //開槍Input
        if (GripFireAction.GetLastStateDown(SteamVR_Input_Sources.Any)) //讀取FireActicon GrapGrip值  
        {
            //OpenFIre();
            GetFire.OpenFIre();
            Debug.Log("OpenFIreVRInput");

        }

        //拿取物件Input
        if (GrapPinchAction.GetLastStateDown(SteamVR_Input_Sources.Any)) //讀取GrapPinchAction GrapPinch值  
        {

            Debug.Log("GrapPinchActionVRInput");

        }

        //搖桿左
        if (SnapTurnLeft.GetLastStateDown(SteamVR_Input_Sources.Any))
        {
            GetFire.ChangeBullectMinus();
            Debug.Log("TurnLeftActionVRInput");

        }

        //搖桿右
        if (SnapTurnRight.GetLastStateDown(SteamVR_Input_Sources.Any))
        {
            GetFire.ChangeBullectPlus();
            Debug.Log("TurnRightActionVRInput");

        }

    }
}