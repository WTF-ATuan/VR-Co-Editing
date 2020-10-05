using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InputData : SingletonMonoBehavior<InputData> {
    [Header("Player")]
    public Player PlayerScript;
    public Hand Hand_R;
    public Hand Hand_L;
    public GameObject HandObjcet;
    [Header("ImportingInput")]
    public SteamVR_Action_Boolean FireButton;
    public SteamVR_Action_Boolean GripButton;
    public SteamVR_Action_Boolean SnapTurnLeft;
    public SteamVR_Action_Boolean SnapTurnRight;
    #region(ComputerInput)
    public bool GetClick {
        get {
            if (Input.GetMouseButtonDown(0))
                return true;
            else
                return false;
        }
    }
    public bool GetRightArrow {
        get {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                return true;
            else
                return false;
        }
    }
    public bool GetLeftArrow {
        get {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                return true;
            else
                return false;
        }
    }
    public Vector3 GetMousePosition {
        get {
            Debug.Log(MousePosition());
            return MousePosition();
        }
    }
    public Vector3 MousePosition() {
        Vector3 mouseposition;
        mouseposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x
            , Input.mousePosition.y, Camera.main.transform.position.z * - 1));
        return mouseposition;
    }
    #endregion
}
