
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
        textMeshPro.text = ScenceData.Data.gameTime.ToString("F1");
    }
}
