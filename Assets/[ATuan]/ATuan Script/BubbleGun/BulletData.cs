using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletData{
    public string name;
    public GameObject gameObject;
    public Material bullectMat;
    public bool isFiring;
    public bool isHit;
    public Material UImat;
    public SoundFile soundFile;
}
[CreateAssetMenu(fileName = "BulletSet", menuName = "Data/Bullet")]
public class BulletSet : ScriptableObject{
    public List<BulletData> bulletSets = new List<BulletData>();
}
