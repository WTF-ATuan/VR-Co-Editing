using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AutoComBinding : MonoBehaviour
{
    public LevelSet levelSet;
    public BulletSet bulletSet;

    public void LevelComBine()
    {
        for (int i = 0; i < levelSet.LevelDatas.Count; i++)
        {
            if (levelSet.LevelDatas[i].anserBullet == null)
            {
                if (bulletSet.bullets[i] != null)
                    levelSet.LevelDatas[i].anserBullet = bulletSet.bullets[i];
                else {
                    Debug.LogError("Bulletset Null");
                }
            }
        }
    }

    public void BulletComBine()
    {


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
            combineData.LevelComBine();
        }
        if (GUILayout.Button("ComBineeBullet"))
        {
            combineData.BulletComBine();
        }
        GUILayout.EndHorizontal();
    }
}
