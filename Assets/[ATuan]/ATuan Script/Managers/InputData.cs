using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

}
