using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class MovieManager : MonoBehaviour
{
    public VideoPlayer Firstvideo = new VideoPlayer();

    public void Update()
    {
        if (Firstvideo.isPaused) {
            SceneManager.LoadScene(2);
        }
    }
}
