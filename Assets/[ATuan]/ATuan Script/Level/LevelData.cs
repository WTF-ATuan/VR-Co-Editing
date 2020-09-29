using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public Material currentMat;
    public Material passMat;
    public SoundFile soundFile;
    public BulletData anserBullet;
    public bool pass;
    public bool miss;
}
[CreateAssetMenu(fileName = "LevelData", menuName = "Data / Level")]
public class LevelSet : ScriptableObject
{
    public List<LevelData> LevelDatas;
    public EventSystem OnPassing;
}