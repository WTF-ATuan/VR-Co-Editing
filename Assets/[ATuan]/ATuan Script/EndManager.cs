using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Charactor");
        Player.transform.position = this.transform.position;
        ViveInput DidntUse = Player.GetComponent<ViveInput>();
        Destroy(DidntUse);
    }
   
}
