using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AutoMeterials : MonoBehaviour
{
   public List<Material> allMaterials;
   public List<Sprite> allSprites;

   public void ComBineName()
   {
      for (int i = 0; i < allMaterials.Count; i++)
      {
         allMaterials[i].name = allSprites[i].texture.name;
      }
   }

   public void ComBineData()
   {
      for (int i = 0; i < allMaterials.Count; i++)
      {
         allMaterials[i].mainTexture = allSprites[i].texture;
      }
   }

   public void ClearMaterials()
   {
      allMaterials.Clear();
   }

   public void Clearsprites()
   {
      allSprites.Clear();
   }
}
[CustomEditor(typeof(AutoMeterials))]
public class MaterialCombine : Editor
{
   public override void OnInspectorGUI()
   {
      base.OnInspectorGUI();
      AutoMeterials combineData = target as AutoMeterials;
      GUILayout.BeginHorizontal();
      if (GUILayout.Button("ComBineName"))
      {
         combineData.ComBineName();
      }
      if (GUILayout.Button("ComBineeData"))
      {
         combineData.ComBineData();
      }
      GUILayout.EndHorizontal();
      GUILayout.BeginHorizontal();
      if (GUILayout.Button("Clear Meterials"))
      {
         combineData.ClearMaterials();
      }

      if (GUILayout.Button("Clear Sprite"))
      {
         combineData.Clearsprites();
      }
      GUILayout.EndHorizontal();
   }
}
