using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
        AwakeMap();
        AwakeLevel();
        AwakeSound();
        AwakePlayer();
        OnStart.Invoke(null);
        DontDestroyOnLoad(this.gameObject);
    }
    [Header("Player")]
    public GameObject player;
    public Camera vrCamera;
    public int playerHp;
    public PlayerManager playerManager;
    public float playerSpeed;
    public GameObject loudGun;
    private void AwakePlayer()
    {
        if (playerHp <= 0) Debug.LogError("NotSetHp");
        if (!player) Debug.LogError("null player");
        if (!vrCamera) Debug.LogWarning("VR Camera miss");
        if (!playerManager) Debug.LogError("null PlayerScript");
        playerManager.Initialize(this);
    }
    [Header("Level")]
    // public LevelManager levelManager;
    public List<EnemyBase> allEnemy;
    public List<BulletSet> allBullets;
    public EnemyBase currentEnemy;
    public BulletSet currentBulletSet;
    public int levelCount;
    private void AwakeLevel()
    {
        if (allEnemy == null) Debug.LogError("Missing Level");
        if (allBullets == null) Debug.LogError("Missing Bullet");
    }
    [Header("GameControl")]
    public float gameTime;
    public Difficulty difficulty;
    public bool isPassLevel;
    public bool isFailLevel;
    public GameManager gameManager;
    private void AwakeGame() {
        if (!gameManager) Debug.LogError("null gameManager");
        gameManager.Initialize(this);
    }
    [Header("Map")]
    public List<GameObject> easyMap;
    public List<GameObject> normalMap;
    public List<GameObject> hardMap;
    public MapManager mapManager;
    private void AwakeMap() {
        if (!mapManager) Debug.LogError("null MapManager");
    }
    [Header("TriggerPoint")]
    public List<Transform> checkPoint;
    public Transform endPoint;
    [Header("Sound")]
    public SoundManager soundManager;

    public List<SoundFile> soundFiles;
    private void AwakeSound() {
        if (!soundManager) Debug.LogError("Sound Miss");
    }
    [Header("Pass or Fail Event")]
    public EventSystem onPass;
    public EventSystem onFail;

}
public enum Difficulty
{
    UnSet,
    Easy,
    Normal,
    Hard
}
