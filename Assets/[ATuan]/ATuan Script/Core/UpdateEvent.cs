using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEvent : MonoBehaviour
{
    public delegate void updateCrtl();
    private static updateCrtl updateEvent;

    public void Update()
    {
        if (updateEvent != null)
            updateEvent.Invoke();
    }
    public static void AddUpdate(updateCrtl action) 
    {
        updateEvent += action;
    }
    public static void RemoveUpdate(updateCrtl action)
    {
        updateEvent -= action;
    }
}
