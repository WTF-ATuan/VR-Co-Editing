using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AutoComBinding : MonoBehaviour
{
    public LevelSet levelSet;
    public BulletSet bulletSet;

    public void BulletComBine()
    {
        for (int i = 0; i < levelSet.LevelDatas.Count; i++)
        {
            levelSet.LevelDatas[i].anserBullet = bulletSet.bullets[i];
        }
    }

    public void BulletNameComBine()
    {
        for (int i = 0; i < levelSet.LevelDatas.Count; i++)
        {
            if(bulletSet.bullets[i].name == null)
                return;
            levelSet.LevelDatas[i].name = bulletSet.bullets[i].name;
        }

    }
}
[CustomEditor(typeof(AutoComBinding))]
public class CombineSystemCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AutoComBinding combineData = target as AutoComBinding;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("ComBineLevel"))
        {
            combineData.BulletComBine();
        }
        if (GUILayout.Button("ComBineeBullet"))
        {
            combineData.BulletNameComBine();
        }
        GUILayout.EndHorizontal();
    }
}
