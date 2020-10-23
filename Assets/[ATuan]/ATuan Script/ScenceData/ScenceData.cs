using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenceData : MonoBehaviour
{
    public EventSystem OnStart;
    public static ScenceData Data;

    private void Awake()
    {
        Data = this;
        AwakePlayer();
        AwakeLevel();
        OnStart.Invoke(null);
    }
    [Header("Player")]
    public GameObject Player;
    public GameObject Boat;
    public GameObject BubbleGun;
    public int PlayerHp;
    private void AwakePlayer()
    {
        if (PlayerHp <= 0)
            Debug.LogError("NotSetHp");
        if (!Player)
            Debug.Log("null player");
        if (!Boat)
            Debug.Log("null boat");
    }
    [Header("Enemy")]
    public EnemyBase[] EasyVersion;
    public EnemyBase[] NormalVersion;
    public EnemyBase[] HardVersion;
    public int EnemyCount;
    public EnemyManager enemyManager;
    private void AwakeEnemy() {
    
    }
    [Header("Level")]
    public LevelManager levelManager;
    public List<LevelSet> AllLevels;
    public List<BulletSet> AllBullets;
    private void AwakeLevel()
    {
        if (!levelManager) Debug.LogError("null LevelManager");
        if (AllLevels == null) Debug.LogError("Missing Level");
        if (AllBullets == null) Debug.LogError("Missing Bullet");
        levelManager.Initialize(this);
    }
    [Header("GameControl")]
    public float GameTime;
    public Difficulty DifficultyChoose;
    [Header("Map")]
    public List<GameObject> EasyMap;
    public List<GameObject> NormalMap;
    public List<GameObject> HardMap;

    [Header("PassEvent")]
    public EventSystem OnPass;
}
public enum Difficulty
{
    Easy,
    Normal,
    Hard
}
