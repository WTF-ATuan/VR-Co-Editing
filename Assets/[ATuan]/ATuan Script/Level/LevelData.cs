using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public string name;
    public Material currentMat;
    public Material passMat;
    public SoundFile soundFile;
    public BulletData anserBullet;
    public bool pass;
    public bool miss;
}
[CreateAssetMenu(fileName = "New LevelData", menuName = "Data / Level")]
public class LevelSet : ScriptableObject
{
    public List<LevelData> LevelDatas;
    public EventSystem OnPassing;
}