using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTime : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    private void Start()
    {
        UpdateEvent.AddUpdate(ToUpdate);
    }

    private void ToUpdate()
    {
        textMeshPro.text = ScenceData.Data.GameTime.ToString();
    }
}
