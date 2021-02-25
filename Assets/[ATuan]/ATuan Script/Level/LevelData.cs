using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New LevelData", menuName = "Data / LevelData")]
public class LevelData : ScriptableObject{
	public BulletData answerBullet;

	[HideInInspector] public GameObject passWordObj;
	[HideInInspector] public GameObject levelObj;
	[MyReadOnly] public bool pass;
	[MyReadOnly] public bool miss;
}