using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletData : MonoBehaviour{
	public new string name;
	public float speed;
	[MyReadOnly] public Rigidbody bubbleRig;
	[MyReadOnly] public bool isHit;
	[MyReadOnly]public bool isFire;
	public Material uiMat;
	public SoundFile soundFile;
	public SoundFile hitSound;
	[MyReadOnly] public Vector3 direction;
}