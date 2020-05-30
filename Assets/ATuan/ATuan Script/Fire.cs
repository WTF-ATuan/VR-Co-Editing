using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Fire : MonoBehaviour {
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform BarrelPivot;
    public GameObject MuzzlerLash;
    public List<Bullet> Magazine;
    public int FullOfMagazine;
    public GameObject[] PrefabJapan = new GameObject[6];

    private Bullet WordBullet;
    private int IndexOfBullet = 0;
    private string[] BullectName = new string[6];
    private Animator animator;
    void Start() {
        animator = GetComponent<Animator>();
        MuzzlerLash.SetActive(false);
        SetBullet();
    }

    public void ChangeBullectPlus() {
        IndexOfBullet++;
        if (IndexOfBullet >= Magazine.Count)
        {
            IndexOfBullet = 0;
        }
    }
    public void ChangeBullectMinus() {
        IndexOfBullet--;
        if (IndexOfBullet >= Magazine.Count || IndexOfBullet < 0)
        {
            IndexOfBullet = 0;
        }
    }
    public List<Bullet> SetBullet() {
        Magazine = new List<Bullet>();
        for (int index = 0; index < PrefabJapan.Length; index++) {
            WordBullet = new Bullet(false, PrefabJapan[index].name, PrefabJapan[index]);
            Magazine.Add(WordBullet);
        }
        return Magazine;

    }
    public void OpenFIre() {
        Debug.Log("Fireing");
        animator.SetTrigger("OpenFire");
        GameObject BulletFromNow = Instantiate(Magazine[IndexOfBullet].gameObject, BarrelPivot.position, Quaternion.identity);
        Rigidbody bulletRb = BulletFromNow.GetComponent<Rigidbody>();
        BulletFromNow.name = Magazine[IndexOfBullet].Name;
        bulletRb.velocity = BarrelPivot.forward * BulletSpeed;
        MuzzlerLash.SetActive(true);
        IndexOfBullet++;
        if (IndexOfBullet >= Magazine.Count) {
            IndexOfBullet = 0;
        }
    }

}
