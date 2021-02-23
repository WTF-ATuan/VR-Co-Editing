using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BulletSet", menuName = "Data/Bullet")]
[System.Serializable]
public class BulletSet : ScriptableObject
{
    public List<BulletData> bullets = new List<BulletData>();
}