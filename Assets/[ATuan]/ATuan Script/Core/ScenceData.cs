using System.Collections;
using System.Collections.Generic;
using Atuan_Script.Core;
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
        start.Invoke(null);
        DontDestroyOnLoad(gameObject);
    }
    [Header("Player")]
    public GameObject player;
    [Header("GameControl")]
    public float gameTime;
    [Header("Sound")]
    public SoundManager soundManager;

    public List<SoundFile> soundFiles;
    [Header("Pass or Fail Event")]
    public EventSystem pass;

}