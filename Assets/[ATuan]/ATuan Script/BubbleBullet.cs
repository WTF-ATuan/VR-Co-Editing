using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
    public AudioSource BubbleSound;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null) {
            BubbleSound.Play();
        }
        if (collision.gameObject.tag == "Question") {
            Destroy(gameObject);
        }
    }
}
