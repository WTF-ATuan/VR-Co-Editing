using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScenceData : MonoBehaviour
{
    public EventSystem start;
    public static ScenceData Data {
        get;
        private set;
    }
    private void Awake()
    {
        Data = this;
        AwakeLevel();
        AwakeSound();
        AwakePlayer();
        start.Invoke(null);
        DontDestroyOnLoad(this.gameObject);
    }
    [Header("Player")]
    public GameObject player;
    public PlayerManager playerManager;
    public float playerSpeed;
    private void AwakePlayer()
    {
        if (!player) Debug.LogError("null player");
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
    public EventSystem pass;
    public EventSystem fail;

}
public enum Difficulty
{
    UnSet,
    Easy,
    Normal,
    Hard
}
