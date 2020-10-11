using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

[RequireComponent(typeof(TeleportArc))]
public class HandPointer : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public GameObject handObject;
    public GameObject pointerObject;
    public LayerMask trackLayer;
    public DataEvent<Vector3> OnHit;

    private TeleportArc teleportArc;
    private SteamVR_Behaviour_Pose vr_pose;
    private bool hasPosition;
    private void Start()
    {
        teleportArc = GetComponent<TeleportArc>();
        teleportArc.traceLayerMask = trackLayer;
        vr_pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
    private void Update()
    {

        hasPosition = PointerUpdate();
        pointerObject.SetActive(hasPosition);

        if (fireAction.GetStateUp(vr_pose.inputSource) || hasPosition)
            OnHit.Invoke(pointerObject.transform.position);
        
    }
    private bool PointerUpdate() {
        Ray ray = new Ray(handObject.transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            pointerObject.transform.position = hit.point;
            return true;
        }

        return false;
    }

}
