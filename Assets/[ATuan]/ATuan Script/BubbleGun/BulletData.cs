using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletData{
    public string name;
    public GameObject gameObject;
    public BubbleData bubbleData;
    public Material bullectMat;
    public bool isFiring {
        get => bubbleData.isFire;    
    }
    public bool isHit {
        get => bubbleData.isHit;
    }
    public Material UImat;
    public SoundFile soundFile;
}
[CreateAssetMenu(fileName = "New BulletSet", menuName = "Data/Bullet")]
public class BulletSet : ScriptableObject{
    public List<BulletData> bullets = new List<BulletData>();
}
