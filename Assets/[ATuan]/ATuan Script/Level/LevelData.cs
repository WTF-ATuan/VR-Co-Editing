using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
[System.Serializable]
public class LevelData:MonoBehaviour
{
    public Material passMat;
    public BulletData anserBullet;
    public bool pass;
    public bool miss;
    public SoundFile goodSound;
    public SoundFile badSound;
}
[CreateAssetMenu(fileName = "New LevelData", menuName = "Data / Level")]
public class LevelSet : ScriptableObject
{
    public EnemyBase Enemy;
    public List<LevelData> LevelDatas;
    public EventSystem OnPassing;

    public void DebugText(string Text)
    {
        Debug.Log(Text);
    }
}
