using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public List<SoundFile> soundFiles = new List<SoundFile>();
    private AudioSource SoundPlayer;
    private void Start()
    {
        SoundPlayer = GetComponent<AudioSource>();
    }
    public void PlaySound(SoundFile file) {
        SoundPlayer.PlayOneShot(file.Sound);
    }
}
[System.Serializable]
public class SoundFile {
    public string Name;
    public AudioClip Sound;
}
