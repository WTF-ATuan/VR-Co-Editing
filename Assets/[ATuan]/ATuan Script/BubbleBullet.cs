using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
    public AudioSource[] BubbleSound;
    public float MaxTime = 5f;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null) {
            BubbleSound[Random.Range(0, BubbleSound.Length)].Play();
        }
    }
    public void Update()
    {
        float time = 0;
        time += Time.deltaTime;
        if (time > MaxTime) {
            Destroy(gameObject);
            Destroy(this);
        }
    }
}
