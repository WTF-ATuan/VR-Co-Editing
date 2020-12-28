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
    public GameObject Player;
    public GameObject Boat;
    public Camera VRCamera;
    public int PlayerHp;
    public PlayerManager playerManager;
    public float playerSpeed;
    public GameObject LoudGun;
    private void AwakePlayer()
    {
        if (PlayerHp <= 0) Debug.LogError("NotSetHp");
        if (!Player) Debug.LogError("null player");
        if (!Boat) Debug.LogError("null boat");
        if (!VRCamera) Debug.LogWarning("VR Camera miss");
        if (!playerManager) Debug.LogError("null PlayerScript");
        playerManager.Initialize(this);
    }
    [Header("Level")]
    public LevelManager levelManager;
    public List<LevelSet> allLevelSets;
    public List<BulletSet> allBullets;
    public LevelSet currentLevelSet;
    public BulletSet currentBulletSet;
    public int LevelCount;
    private void AwakeLevel()
    {
        if (!levelManager) Debug.LogError("null LevelManager");
        if (allLevelSets == null) Debug.LogError("Missing Level");
        if (allBullets == null) Debug.LogError("Missing Bullet");
        levelManager.Initialize(this);
    }
    [Header("GameControl")]
    public float GameTime;
    public Difficulty Difficulty;
    public bool IsPassLevel;
    public bool IsFailLevel;
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
    public Transform EndPoint;
    public Transform StartPoint;
    [Header("Sound")]
    public SoundManager soundManager;

    public List<SoundFile> soundFiles;
    private void AwakeSound() {
        if (!soundManager) Debug.LogError("Sound Miss");
    }
    [Header("Pass or Fail Event")]
    public EventSystem OnPass;
    public EventSystem OnFail;

}
public enum Difficulty
{
    UnSet,
    Easy,
    Normal,
    Hard
}
