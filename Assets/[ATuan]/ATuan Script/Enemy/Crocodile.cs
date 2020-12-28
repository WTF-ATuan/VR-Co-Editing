using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : EnemyBase
{
    [SerializeField] private EventSystem OnFailEvent;
    [SerializeField] private EventSystem OnPassEvent;
    [SerializeField] private GameObject changingMeshObject;
    protected override Vector3 TargetPosition
    {
        get => ScenceData.Data.StartPoint.position;
    }

    protected override void Onhit()
    {
    }

    protected override void OnPass()
    {
        anserObject.SetActive(true);
        EnemyAnimator.SetBool("isdead", true);
        OnPassEvent.Invoke(null);
    }

    protected override void OnFail()
    {
        OnFailEvent.Invoke(null);
    }
//For Testing
    public void ChangeMesh(Material material)
    {
        changingMeshObject.SetActive(true);
        MeshRenderer mesh = changingMeshObject.GetComponent<MeshRenderer>();
        mesh.material = material;
    }
}