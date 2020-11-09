using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletData : MonoBehaviour{
    public string name;
    public float Speed;
    [HideInInspector]
    public GameObject gameObject;
    [HideInInspector]
    public Rigidbody bubbleRig;
    public bool isHit;
    public Material UImat;
    public SoundFile soundFile;
    public SoundFile HitSound;

}
[CreateAssetMenu(fileName = "New BulletSet", menuName = "Data/Bullet")]
public class BulletSet : ScriptableObject{
    public List<BulletData> bullets = new List<BulletData>();
}
