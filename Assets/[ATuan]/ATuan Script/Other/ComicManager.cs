using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComicManager : MonoBehaviour
{
    public List<Sprite> comics;
    public Image imageChanger;
    public string sceneName;
    private int comicCount;
    public bool isOver;

    private void Update()
    {
        if (InputData.instance.GripAction)
        {
            comicCount++;
            ChangeImage();
        }
        if(isOver)
            SceneManager.LoadScene(sceneName);
        
            
    }

    private void ChangeImage()
    {
        if (comicCount >= comics.Count)
        {
            isOver = true;
        }

        imageChanger.sprite = comics[comicCount];
    }
}
