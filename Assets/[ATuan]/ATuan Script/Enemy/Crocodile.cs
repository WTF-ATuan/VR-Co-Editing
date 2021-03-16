using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crocodile : EnemyBase
{
    private static readonly int IsDead = Animator.StringToHash("isDead");

    protected override void OnPass(){
        EnemyAnimator.SetBool(IsDead, true);
    }
    

    public void LoadScene(){
        SceneManager.LoadScene("zArt_End");
    }


}