using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Fire : MonoBehaviour {
    [SerializeField] private GameObject[] BubbleObj = new GameObject[6];
    [SerializeField] private string[] BulletName = new string[6];
    [SerializeField] private GameObject MuzzlerLash;

    public GameObject Bullet;
    public float BulletSpeed;
    public Transform BarrelPivot;
   
    public List<Bullet> Magazine;
    public int IndexOfBullet = 0;
   

    private Animator animator;
    private Bullet WordBullet;
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
    public void InputOFComputer() {
        if (Input.GetMouseButtonDown(0)) {
            OpenFIre();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            IndexOfBullet++;
            if (IndexOfBullet >= Magazine.Count) {
                IndexOfBullet = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            IndexOfBullet--;
            if (IndexOfBullet >= Magazine.Count) {
                IndexOfBullet = 0;
            }
        }
    }
    public List<Bullet> SetBullet() {
        Magazine = new List<Bullet>();
        for (int index = 0; index < BubbleObj.Length; index++) {
            WordBullet = new Bullet(false, BubbleObj[index].name, BubbleObj[index]);
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
