using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private List<SoundFile> _soundFiles = new List<SoundFile>();
    private AudioSource _soundPlayer;
    private Transform _playerPosition;
    private void Start()
    {
        _playerPosition = ScenceData.Data.player.transform;
        _soundPlayer = GetComponent<AudioSource>();
    }

    public void Initialize(ScenceData data){
        _soundFiles = data.soundFiles;
    }

    public void PlaySound(SoundFile file)
    {
        transform.position = _playerPosition.position;
        _soundPlayer.PlayOneShot(file.Sound);
    }

    public void PlaySound(SoundFile file, Vector3 position)
    {
        transform.position = position;
        _soundPlayer.PlayOneShot(file.Sound);
    }
}
[System.Serializable]
public class SoundFile {
    public string Name => Sound.name;
    public AudioClip Sound;
}
