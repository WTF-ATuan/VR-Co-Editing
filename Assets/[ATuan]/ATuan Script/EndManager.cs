using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public Animator Man, Grandma, Lady;

    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Charactor");
        Player.transform.position = this.transform.position;
        ViveInput DidntUse = Player.GetComponent<ViveInput>();
        Destroy(DidntUse);
        Man.SetBool("Thank", true);
        Grandma.SetBool("Thank", true);
        Lady.SetBool("Thank", true);
    }
   
}
