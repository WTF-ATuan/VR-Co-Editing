using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigger : MonoBehaviour
{

    public GameObject PassObjcet = null;
    public bool Pass = false;
    public GameObject AnserObject = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == PassObjcet.name)
            {
                GameObject Obj = other.gameObject;
                ChangeImage(Obj);
                IsPassing(Obj);
            }
            else
            {
                IsFall();
            }
        }
    }
    public void ChangeImage(GameObject obj)
    {
        GameObject AnserObj = Instantiate(obj, transform.position, obj.transform.rotation);
        AnserObj.transform.SetParent(this.transform);
        Rigidbody AnserObjRig = AnserObj.GetComponent<Rigidbody>();
        SphereCollider sphere = AnserObj.GetComponent<SphereCollider>();
        Destroy(AnserObjRig);
        Destroy(sphere);
    }
    public void IsPassing(GameObject Obj)
    {
        Debug.Log("Good Job");
        AnserObject = Obj;
        Pass = true;
        if (!StageTeachManager.instance.PassingTeachStage)
            StageTeachManager.instance.successSound.Play();
        else
            GameManager.instance.successSound.Play();

    }
    public void IsFall()
    {
        Debug.Log("Not the Same Obj");
        if (!StageTeachManager.instance.PassingTeachStage)
            StageTeachManager.instance.failSound.Play();
        else
            GameManager.instance.failSound.Play();
    }
}
