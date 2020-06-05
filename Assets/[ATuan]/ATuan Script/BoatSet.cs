using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float MaxDistance;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    public void Update()
    {

    }
    public void BoatMove(Vector3 TargetPosition, float SmoothTime)
    {
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref velocity, SmoothTime);
    }
}
    