using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ComponentSystem : MonoBehaviour {
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