using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Fire : MonoBehaviour {
    [SerializeField] private GameObject MuzzlerLash;
    [SerializeField] private float BulletSpeed;
    public Transform BarrelPivot;
    public List<Bullet> Magazine;
    public int IndexOfBullet;

    [SerializeField]private Animator animator;
    private Bullet WordBullet;
    public  float Timer = 0;
    private float ColdDownTime = 1.5f;
    void Start() {
        //animator = GetComponent<Animator>();
        MuzzlerLash.SetActive(false);
    }
    public void RemoveBullet(string BulletName) {
        for (int i = 0; i < Magazine.Count; i++) {
            if (Magazine[i].Name == BulletName) {
                Magazine.RemoveAt(i);
                Debug.Log("Remove" + Magazine[i].gameObject);
            }
        }

    }
    public void ChangeBullectPlus() {
        IndexOfBullet++;
        if (IndexOfBullet >= Magazine.Count) {
            IndexOfBullet = 0;
        }
    }
    public void ChangeBullectMinus() {
        IndexOfBullet--;
        if (IndexOfBullet >= Magazine.Count || IndexOfBullet < 0) {
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
    public void SetBullet(GameObject[] Bubble) {
        Magazine = null;
        Magazine = new List<Bullet>();
        for (int index = 0; index < Bubble.Length; index++) {
            WordBullet = new Bullet(false, Bubble[index].name, Bubble[index]);
            Magazine.Add(WordBullet);
        }
    }
    public void OpenFIre() {
        animator.SetTrigger("OpenFire");
        Timer = ColdDownTime;
        GameObject BulletFromNow = Instantiate(Magazine[IndexOfBullet].gameObject, BarrelPivot.position,transform.rotation);
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
