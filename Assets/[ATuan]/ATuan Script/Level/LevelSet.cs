using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New LevelSet", menuName = "Data / LevelSet")]
[System.Serializable]
public class LevelSet : ScriptableObject
{
    public Material passMat;
    public Material errorMat;
    public Material startMat;

}