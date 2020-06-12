using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSet : MonoBehaviour
{

    [SerializeField] public Vector3 velocity = Vector3.zero;
    public void BoatMove(Vector3 TargetPosition, float SmoothTime)
    {
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref velocity, SmoothTime);
    }
}
    