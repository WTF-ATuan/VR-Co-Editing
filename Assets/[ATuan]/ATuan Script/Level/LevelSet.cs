using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New LevelData", menuName = "Data / LevelSet")]
[System.Serializable]
public class LevelSet : ScriptableObject
{
    public List<LevelData> levelData;

}