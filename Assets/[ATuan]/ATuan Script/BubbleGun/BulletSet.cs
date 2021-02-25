using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BulletSet", menuName = "Data / BulletSet")]
[System.Serializable]
public class BulletSet : ScriptableObject
{
    public List<BulletData> bullets = new List<BulletData>();
}