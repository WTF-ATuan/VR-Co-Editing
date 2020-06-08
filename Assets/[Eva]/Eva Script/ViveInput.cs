using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;




public class ViveInput : MonoBehaviour {
    [Header("PlayerObject")]
    [SerializeField] public Fire fire;
    [SerializeField] private Valve.VR.InteractionSystem.Interactable InteractableOfGun;
    [SerializeField] private GameObject LoudPublic;

    [Header("PlayerInput")]
    [SerializeField] private Hand RightHand;
    [SerializeField] private Hand LeftHand;

    [Header("PlayerTeleport")]
    public bool TeleportFuntion = true;
    [SerializeField] public Teleport teleportManager;
    [Header("PlayerHandInput")]
    public SteamVR_Action_Boolean GripFireAction;
    public SteamVR_Action_Boolean GrapPinchAction;
    public SteamVR_Action_Boolean SnapTurnLeft = SteamVR_Input.GetBooleanAction("TurnLeft");
    public SteamVR_Action_Boolean SnapTurnRight = SteamVR_Input.GetBooleanAction("TurnRight");
    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);
    public bool LockingGun = true;

    private void FixedUpdate() {
        InputOfVRSet();
    }
    private bool Timer() {
        if (!Timer()) {
            float sum = 0.5f;
            sum -= Time.deltaTime;
            if (sum < 0)
                return true;
        }
        if (Timer()) {
            float sum = 0.5f;
            sum -= Time.deltaTime;
            if (sum < 0)
                return false;
        }
        return Timer();
           
    }

    public void InputOfVRSet() {
        GrabTypes StartGrab = RightHand.GetBestGrabbingType();
        //開槍Input
        if (GripFireAction.GetLastStateDown(SteamVR_Input_Sources.RightHand)) //讀取FireActicon GrapGrip值  
        {
            Debug.Log("OpenFIreVRInput");
            if (RightHand.currentAttachedObject != null && RightHand.currentAttachedObject == LoudPublic && Timer())
                fire.OpenFIre();

        }
        //拿取物件Input
        if (RightHand.currentAttachedObject == null && StartGrab != GrabTypes.None) {
            if (GrapPinchAction.GetLastStateDown(SteamVR_Input_Sources.Any)) //讀取GrapPinchAction GrapPinch值  
            {
                Debug.Log("GrapPinchActionVRInput");
                if (RightHand.IsStillHovering(InteractableOfGun)) {
                    if (LockingGun) {
                        RightHand.HoverLock(InteractableOfGun);
                        RightHand.AttachObject(LoudPublic, StartGrab, attachmentFlags);
                    } else if (!LockingGun) {
                        RightHand.DetachObject(LoudPublic);
                        RightHand.HoverUnlock(InteractableOfGun);

                    }
                }
               

            }
        }
        if (RightHand.currentAttachedObject == LoudPublic && !LockingGun) {
            RightHand.DetachObject(LoudPublic);
            RightHand.HoverUnlock(InteractableOfGun);
        }
            //搖桿左
            if (SnapTurnLeft.GetLastStateDown(SteamVR_Input_Sources.RightHand)) {

            Debug.Log("TurnLeftActionVRInput");
            if (RightHand.currentAttachedObject != null && RightHand.currentAttachedObject == LoudPublic)
                fire.ChangeBullectMinus();
        }

        //搖桿右
        if (SnapTurnRight.GetLastStateDown(SteamVR_Input_Sources.RightHand) && RightHand.currentAttachedObject == LoudPublic) {

            Debug.Log("TurnRightActionVRInput");
            if (RightHand.currentAttachedObject != null && RightHand.currentAttachedObject == LoudPublic)
                fire.ChangeBullectPlus();
        }

    }
}