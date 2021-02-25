using System;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InputData : SingletonMonoBehavior<InputData>
{
    [Header("Hand")] public Hand hand;
    public SteamVR_Action_Vibration hapticAction;


    private Hand.AttachmentFlags _attachmentFlags;
    private void Start()
    {
        _attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) &
                          (~Hand.AttachmentFlags.DetachOthers) &
                          (~Hand.AttachmentFlags.VelocityMovement);
    }
   

    public GameObject HandObject => hand.currentAttachedObject;
    

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

   
    public void Equip(Interactable obj)
    {
        hand.HoverLock(obj);
        hand.AttachObject(obj.gameObject, GrabTypes.Pinch, _attachmentFlags);
    }
    public void Haptic(float shakeTime, SteamVR_Input_Sources source, float amplitude)
    {
        hapticAction.Execute(Time.time, shakeTime, 150, amplitude, source);
    }
}