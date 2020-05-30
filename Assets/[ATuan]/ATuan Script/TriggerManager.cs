using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager triggerManager;

    private void Awake() {
        triggerManager = this;

    }
   
}
