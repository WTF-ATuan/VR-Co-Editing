using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class LevelData
{
    public string LevelName;
    public BulletSet LevelBullet;
    public int Level;
    public LevelData() {
    
    
    }
    
}
=======
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
>>>>>>> 7a72498107cba850e3cd8df7ccbeecbd42583360
