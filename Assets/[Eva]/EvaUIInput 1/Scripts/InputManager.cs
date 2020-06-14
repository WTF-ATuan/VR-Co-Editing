using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InputManager : MonoBehaviour
{
    [Header("Actions")]
    //public SteamVR_Action_Boolean GripFireAction;
    public SteamVR_Action_Boolean SnapTurnLeft = SteamVR_Input.GetBooleanAction("TurnLeft");
    public SteamVR_Action_Boolean SnapTurnRight = SteamVR_Input.GetBooleanAction("TurnRight");
    

    [Header("Scence Objects")]
    public RadialMenu radialMenu = null;
    


    public void Update()
    {
        VRSnapInput();
       
    }

    public void VRSnapInput()
    {
        //搖桿左
        if (SnapTurnLeft.GetLastStateDown(SteamVR_Input_Sources.Any)) //讀取SnapTurnLeft值
        {
            radialMenu.TurnLeft();
            Debug.Log("TurnLeftActionVRInput");

        }

        //搖桿右
        if (SnapTurnRight.GetLastStateDown(SteamVR_Input_Sources.Any)) //讀取SnapTurnRight值
        {
            radialMenu.TurnRight();
            
            Debug.Log("TurnRightActionVRInput");

        }
       

    }
   
        





    
}
