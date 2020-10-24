using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpdateEvent : MonoBehaviour
{
    public static UnityEvent updatEvent;

    public void Update()
    {
        if (updatEvent != null)
            updatEvent.Invoke();
    }
    public static void AddUpdate(UnityAction action) 
    {
        updatEvent.AddListener(action);
    }
    public static void RemoveUpdate(UnityAction action)
    {
        updatEvent.RemoveListener(action);
    }
    public static int UpdateCount() {
        return updatEvent.GetPersistentEventCount();
    }
}
