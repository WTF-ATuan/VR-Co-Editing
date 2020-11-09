using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private List<SoundFile> soundFiles = new List<SoundFile>();
    private AudioSource SoundPlayer;
    private Vector3 playerPosition;
    private void Start()
    {
        playerPosition = ScenceData.Data.Player.transform.position;
        SoundPlayer = GetComponent<AudioSource>();
    }

    public void Initialize(ScenceData data){
        soundFiles = data.soundFiles;
    }

    public void PlaySound(SoundFile file)
    {
        transform.position = playerPosition;
        SoundPlayer.PlayOneShot(file.Sound);
    }

    public void PlaySound(SoundFile file, Vector3 position)
    {
        transform.position = position;
        SoundPlayer.PlayOneShot(file.Sound);
    }
}
[System.Serializable]
public class SoundFile {
    public string Name => Sound.name;
    public AudioClip Sound;
}
