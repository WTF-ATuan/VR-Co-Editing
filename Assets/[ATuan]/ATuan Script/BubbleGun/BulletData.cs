using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New BulletData", menuName = "Data / BulletData")]
public class BulletData : ScriptableObject{
	public GameObject bulletObject;
	[HideInInspector] public float speed;
	[HideInInspector] public Vector3 direction;
	public new string name;
	[MyReadOnly] public bool isHit;
	[MyReadOnly] public bool isFire;
	public Material uiMat;
	public SoundFile soundFile;
	public SoundFile hitSound;
}