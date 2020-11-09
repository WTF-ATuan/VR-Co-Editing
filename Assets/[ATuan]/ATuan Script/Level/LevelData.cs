using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelData:MonoBehaviour
{
    public string name;
    public Material passMat;
    public BulletData anserBullet;
    public bool pass;
    public bool miss;
    public SoundFile passSound;
    public SoundFile missSound;
}
[CreateAssetMenu(fileName = "New LevelData", menuName = "Data / Level")]
public class LevelSet : ScriptableObject
{
    public EnemyBase Enemy;
    public List<LevelData> LevelDatas;
    public EventSystem OnPassing;
}
