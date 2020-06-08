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

    private Animator animator;
    private Bullet WordBullet;
    void Start() {
        //animator = GetComponent<Animator>();
        MuzzlerLash.SetActive(false);
    }
    public void RemoveBullet(GameObject Bullet) {
        for (int i = 0; i < Magazine.Count; i++) {
            if (Magazine[i].gameObject == Bullet) {
                Magazine.Remove(Magazine[i]);
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
        Magazine = new List<Bullet>();
        for (int index = 0; index < Bubble.Length; index++) {
            WordBullet = new Bullet(false, Bubble[index].name, Bubble[index]);
            Magazine.Add(WordBullet);
        }

    }
    public void OpenFIre() {
        Debug.Log("Fireing");
        //animator.SetTrigger("OpenFire");
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
