using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    [Header("槍枝控制")]
    public GameObject MuzzlerLash;
    public float BulletSpeed;
    public float ColdDownTime = 1.5f;
    public Transform BarrelPivot;
    public List<BulletData> Magazine;
    public int IndexOfBullet;
    private Animator GunAnimator;
    public float Timer = 0;
    void Start()
    {
        //animator = GetComponent<Animator>();
        MuzzlerLash.SetActive(false);
    }
    public void RemoveBullet(string BulletName)
    {
        for (int i = Magazine.Count - 1; i > -1; i--)
        {
            if (Magazine[i].name == BulletName)
            {
                Magazine.RemoveAt(i);
            }
            if (IndexOfBullet == i)
            {
                IndexOfBullet = 0;
            }
        }
    }
    public void ChangeBullectPlus()
    {
        GunAnimator.SetTrigger("OnChangeBullet");
        IndexOfBullet++;
        if (IndexOfBullet >= Magazine.Count)
        {
            IndexOfBullet = 0;
        }
    }
    public void ChangeBullectMinus()
    {
        IndexOfBullet--;
        GunAnimator.SetTrigger("BulletMoviing");
        if (IndexOfBullet >= Magazine.Count || IndexOfBullet < 0)
        {
            IndexOfBullet = 0;
        }
    }
    public void SetBullet(BulletData[] Bubble)
    {
        Magazine = null;
        Magazine = new List<BulletData>(Bubble);
    }
    public void OpenFIre()
    {
        if (Magazine != null)
        {
            GunAnimator.SetTrigger("OpenFire");
            Timer = ColdDownTime;
            GameObject bullect = Instantiate(Magazine[IndexOfBullet].gameObject, BarrelPivot.position, Magazine[IndexOfBullet].gameObject.transform.rotation);
            Rigidbody bulletRb = bullect.GetComponent<Rigidbody>();
            bullect.name = Magazine[IndexOfBullet].name;
            bulletRb.velocity = BarrelPivot.forward * BulletSpeed;
            MuzzlerLash.SetActive(true);
            IndexOfBullet++;
            if (IndexOfBullet >= Magazine.Count)
            {
                IndexOfBullet = 0;
            }
        }
        else
            Debug.LogError("Missing Bullcet");
       
    }
    
}
