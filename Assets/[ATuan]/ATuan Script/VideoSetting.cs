using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSetting : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private double VideoTime;
    private double timeFromnow;
    public void Start()
    {
        VideoTime = videoPlayer.length - 0.7f;
    }
    void Update()
    {
        timeFromnow += Time.deltaTime;
        if (timeFromnow > VideoTime)
        {
            videoPlayer.Pause();
        }
        if (videoPlayer.isPaused == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), Time.deltaTime * 0.2f);
            Invoke("DestroySelf", 8f);
        }
    }
    void DestroySelf()
    {
        StageTeachManager.instance.TelePortFuntion.SetActive(true);
        Destroy(this.gameObject);
        Destroy(this);
    }
}
