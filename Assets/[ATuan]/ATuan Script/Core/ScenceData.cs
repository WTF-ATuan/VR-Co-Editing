using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenceData : MonoBehaviour
{
    public EventSystem OnStart;
    public static ScenceData Data {
        get;
        private set;
    }

    private void Awake()
    {
        Data = this;
        AwakeGame();
        AwakePlayer();
        AwakeMap();
        AwakeLevel();
        AwakeEnemy();
        AwakeSound();
        OnStart.Invoke(null);
    }
    [Header("Player")]
    public GameObject Player;
    public GameObject Boat;
    public GameObject BubbleGun;
    public Camera VRCamera;
    public int PlayerHp;
    private void AwakePlayer()
    {
        if (PlayerHp <= 0)
            Debug.LogError("NotSetHp");
        if (!Player)
            Debug.LogError("null player");
        if (!Boat)
            Debug.LogError("null boat");
        if (!VRCamera) Debug.LogWarning("VR Camera miss");
    }
    [Header("Enemy")]
    public EnemyBase[] EasyVersion;
    public EnemyBase[] NormalVersion;
    public EnemyBase[] HardVersion;
    public int EnemyCount;
    public EnemyManager enemyManager;
    private void AwakeEnemy() {
        if (!enemyManager) Debug.LogError("null EnemyManager");
        enemyManager.Initialize(this);
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
    public Difficulty Difficulty;
    public GameManager gameManager;
    private void AwakeGame() {
        if (!gameManager) Debug.LogError("null gameManager");
        gameManager.Initialize(this);
    }
    [Header("Map")]
    public List<GameObject> EasyMap;
    public List<GameObject> NormalMap;
    public List<GameObject> HardMap;
    public MapManager mapManager;
    private void AwakeMap() {
        if (!mapManager) Debug.LogError("null MapManager");
    }
    [Header("TriggerPoint")]
    public List<Transform> CheckPoint;
    public List<Transform> EndPoint;
    [Header("Sound")]
    public SoundManager soundManager;
    private void AwakeSound() {
        if (!soundManager) Debug.LogError("Sound Miss");
    }
    [Header("PassEvent")]
    public EventSystem OnPass;
}
public enum Difficulty
{
    UnSet,
    Easy,
    Normal,
    Hard
}
