using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Fire : MonoBehaviour {
    public SteamVR_Action_Boolean FireAction;
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
    private Interactable interactable;
    void Start() {
        animator = GetComponent<Animator>();
        MuzzlerLash.SetActive(false);
        //interactable.GetComponent<Interactable>();
        SetBullet();
    }

    void Update() {

        InputOFComputer();
        InputOfVRSet();
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
    public void InputOfVRSet() {
        //if (interactable.attachedToHand != null) {

        //    SteamVR_Input_Sources source = interactable.attachedToHand.handType;

        //    if (FireAction[source].stateDown) {
        //        OpenFIre();
        //    }

        //}
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
