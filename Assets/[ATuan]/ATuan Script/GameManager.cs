using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;
    public bool TeachStage = false;
    public bool FirstStage = false;
    public bool SceondStage = false;
    public bool ThirdStage = false;

    public void Awake() {
        gameManager = this;
    }
    public void Update() {

    }
}
