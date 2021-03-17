using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BulletSet", menuName = "Data / BulletSet")]
[System.Serializable]
public class BulletSet : ScriptableObject
{
    public List<Bullet> bullets = new List<Bullet>();
}