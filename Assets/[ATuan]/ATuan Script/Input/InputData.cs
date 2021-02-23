using System;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InputData : SingletonMonoBehavior<InputData>
{
    [Header("Hand")] public Hand hand;
    public SteamVR_Action_Vibration hapticAction;


    private Hand.AttachmentFlags attachmentFlags;
    private void Start()
    {
        attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) &
                          (~Hand.AttachmentFlags.DetachOthers) &
                          (~Hand.AttachmentFlags.VelocityMovement);
    }
   

    public GameObject HandObject => hand.currentAttachedObject;


    // public Hand HandTouch =>
    //     HoveringObject ? HoveringObject.hoveringHand : null;

    public Interactable HoveringObject => hand.hoveringInteractable;

    public bool FireAction => fireButton.GetLastState(hand.handType);

    public bool GripAction => fireButton.GetLastState(hand.handType) ||
                              gripButton.GetLastState(hand.handType);

    public bool TurnLeftAction => snapTurnLeft.GetLastState(hand.handType);
    public bool TurnRightAction => snapTurnRight.GetLastState(hand.handType);


    [Header("Input")] [SerializeField]
    private SteamVR_Action_Boolean fireButton;

    [SerializeField] private SteamVR_Action_Boolean gripButton;
    [SerializeField] private SteamVR_Action_Boolean snapTurnLeft;
    [SerializeField] private SteamVR_Action_Boolean snapTurnRight;

   
    public void Equip(Interactable obj, Hand hand)
    {
        hand.HoverLock(obj);
        hand.AttachObject(obj.gameObject, GrabTypes.Pinch, attachmentFlags);
        hand.HideController();
    }
    public void Haptic(float ShakeTime, SteamVR_Input_Sources source, float amplitude)
    {
        hapticAction.Execute(Time.time, ShakeTime, 150, amplitude, source);
    }
}