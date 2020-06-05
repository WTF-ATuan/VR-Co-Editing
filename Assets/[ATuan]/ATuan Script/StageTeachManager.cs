using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class StageTeachManager : MonoBehaviour
{
    [SerializeField] private List<TeleportPoint> teleportPoints = new List<TeleportPoint>(); 
    [SerializeField] private Teleport teleportBehaviour;
    [SerializeField] private Hand RightHand;
    [SerializeField] private Hand LeftHand;
    [SerializeField] private Fire openFire;

    void Update()
    {

    }
}
