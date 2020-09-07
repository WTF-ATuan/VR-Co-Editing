using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ComponentSystem : MonoBehaviour {
    public MyEnvent Event;
    public void Start()
    {
        OnStart();
    }
    public void Update()
    {
        OnUpdate();
    }
    public virtual void OnUpdate() { }
    public virtual void OnStart() { }
}
[System.Serializable]
public class MyEnvent : UnityEvent<object> { }
