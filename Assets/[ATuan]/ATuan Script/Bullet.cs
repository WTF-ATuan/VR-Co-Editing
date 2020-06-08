using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet 
{
    public string Name;
    public bool IsFire;
    public GameObject gameObject;
    public Bullet(bool a_isFire , string a_Name , GameObject a_gameobject) {
        Name = a_Name;
        IsFire = a_isFire;
        gameObject = a_gameobject;
    }
}
