using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGunUI : MonoBehaviour
{
    public MeshRenderer UIMesh;
    private GunData gunData;

    public void Initialize(GunData data)
    {
        gunData = data;
    }
    public void ChangingMesh()
    {
        UIMesh.material = gunData.currentBullet.UImat;
    }
}
