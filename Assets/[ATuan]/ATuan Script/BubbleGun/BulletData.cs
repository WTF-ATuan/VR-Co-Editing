using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New BulletData", menuName = "Data / BulletData")]
public class BulletData : ScriptableObject{
	public Material uiMat;
	public SoundFile soundFile;
}