using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;




public class ViveInput : MonoBehaviour {
    [Header("PlayerObject")]
    [SerializeField] public Fire fire;
    [SerializeField] public Valve.VR.InteractionSystem.Interactable InteractableOfGun;
    [SerializeField] public GameObject LoudPublic;

    [Header("PlayerInput")]
    [SerializeField] public Hand RightHand;
    [SerializeField] private Hand LeftHand;

    [Header("PlayerHandInput")]
    public SteamVR_Action_Boolean GripFireAction;
    public SteamVR_Action_Boolean GrapPinchAction;
    public SteamVR_Action_Boolean SnapTurnLeft = SteamVR_Input.GetBooleanAction("TurnLeft");
    public SteamVR_Action_Boolean SnapTurnRight = SteamVR_Input.GetBooleanAction("TurnRight");
    public Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);
    public bool LockingGun = true;
    public GrabTypes StartGrab;

    private void Update()
    {
        if (LoudPublic == null) {
            LoudPublic = GameObject.FindGameObjectWithTag("LoudGun");
            fire = LoudPublic.GetComponent<Fire>();
            InteractableOfGun = LoudPublic.GetComponent<Valve.VR.InteractionSystem.Interactable>();
        }
    }

    private void FixedUpdate() {
        InputOfVRSet();
        fire.Timer -= Time.deltaTime;
    }

    public void InputOfVRSet() {
        StartGrab = RightHand.GetBestGrabbingType();
        //開槍Input
        if (GripFireAction.GetLastStateDown(SteamVR_Input_Sources.RightHand)) //讀取FireActicon GrapGrip值  
        {
            //Debug.Log("OpenFIreVRInput");
            if (RightHand.currentAttachedObject != null && RightHand.currentAttachedObject == LoudPublic && fire.Timer < 0)
                fire.OpenFIre();
        }
        //拿取物件Input
        if (RightHand.currentAttachedObject == null && StartGrab != GrabTypes.None) {
            if (GrapPinchAction.GetLastStateDown(SteamVR_Input_Sources.Any) || GripFireAction.GetLastStateDown(SteamVR_Input_Sources.RightHand)) //讀取GrapPinchAction GrapPinch值  
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
        if (SnapTurnLeft.GetLastStateDown(SteamVR_Input_Sources.Any)) {

            Debug.Log("TurnLeftActionVRInput");
            if (RightHand.currentAttachedObject != null && RightHand.currentAttachedObject == LoudPublic)
                fire.ChangeBullectMinus();
        }

        //搖桿右
        if (SnapTurnRight.GetLastStateDown(SteamVR_Input_Sources.Any) && RightHand.currentAttachedObject == LoudPublic) {

            Debug.Log("TurnRightActionVRInput");
            if (RightHand.currentAttachedObject != null && RightHand.currentAttachedObject == LoudPublic)
                fire.ChangeBullectPlus();
        }

    }
    public void CheckingHand() {
        GrabTypes StartGrab = RightHand.GetBestGrabbingType();
        if (RightHand.currentAttachedObject != LoudPublic) {
            RightHand.AttachObject(LoudPublic, StartGrab, attachmentFlags);
        }
    }
}