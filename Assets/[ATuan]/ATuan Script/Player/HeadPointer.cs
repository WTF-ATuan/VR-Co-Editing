using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPointer : SingletonMonoBehavior<HeadPointer> {
    public bool IsActive;
    public bool DebugLine;
    public event System.Action<PointerData> PointOnHit;
    [SerializeField]
    private Transform HeadTransform;
    private Ray ray;
    [SerializeField]
    [Range(10, 100)]
    private float DebugLineLengh;

    public void Update()
    {
        if (IsActive)
        {
            HeadRayOpen();
        }
    }
    public void HeadRayOpen()
    {
        RaycastHit raycastHit;
        if (DebugLine)
        {
            Debug.DrawRay(HeadTransform.position, HeadTransform.rotation * Vector3.forward * DebugLineLengh, Color.red, 3f); ;
        }
        if (Physics.Raycast(HeadTransform.position, Vector3.forward, out raycastHit, Mathf.Infinity))
        {
            if (raycastHit.collider.GetComponent<IReturnHit>() != null)
            {
                PointerData data = new PointerData()
                {
                    targetPosition = raycastHit.point,
                    targerDistance = raycastHit.distance,
                    returnHit = raycastHit.collider.GetComponent<IReturnHit>(),
                };
                PointOnHit(data);
            }
        }
    }

}
public struct PointerData {
    public Vector3 targetPosition;
    public float targerDistance;
    public IReturnHit returnHit;
}
public interface IReturnHit {
    GameObject HitObject();
    void OnHit();
    float HitTime();
}
