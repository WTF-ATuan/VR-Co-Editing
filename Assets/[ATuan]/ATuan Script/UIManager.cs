using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject WitchStage;
    void Start()
    {
        WitchStage.SetActive(true);
    }
    public void SwitchUI(int Index , GameObject[] UIBubbles , GameObject FireUI) {
        //設FireUI 在 UIBubbles 的 index上
    }
}
