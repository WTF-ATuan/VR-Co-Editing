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
        for (int i = 0; i < levelSet.levelData.Count; i++)
        {
            levelSet.levelData[i].answerBullet = bulletSet.bullets[i];
        }
    }

    public void BulletNameComBine()
    {
        for (int i = 0; i < levelSet.levelData.Count; i++)
        {
            if(bulletSet.bullets[i].name == null)
                return;
            levelSet.levelData[i].name = bulletSet.bullets[i].name;
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
