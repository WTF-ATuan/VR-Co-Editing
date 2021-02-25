using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New LevelSet", menuName = "Data / LevelSet")]
[System.Serializable]
public class LevelSet : ScriptableObject
{
    public List<LevelData> levelData;
    public Material passMat;
    public Material errorMat;
    public Material startMat;
    public SoundFile goodSound;
    public SoundFile badSound;

}