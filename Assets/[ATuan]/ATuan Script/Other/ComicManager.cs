using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComicManager : MonoBehaviour{
	public List<Sprite> comics;
	public Image[] imageChangers;
	[SerializeField] private int comicNum;

	[SerializeField] private string nextScenceName;
	[SerializeField] private GameObject water;
	

	private void Update(){
		if(HandInput.Input.PinchPress && HandInput.Input.SnapRight){
			comicNum++;
			ChangeImage();
		}

		if(HandInput.Input.SnapLeft){
			comicNum--;
			if(comicNum < 0){
				comicNum = comics.Count - 1;
			}

			ChangeImage();
		}
		if(comicNum == 6){
			WaterComeUp();
		}
	}

	private void ChangeImage(){
		if(comicNum >= comics.Count){
			StartCoroutine(DelayChange(2.5f));
		}
		
		foreach(var image in imageChangers){
			image.sprite = comics[comicNum];
		}
	}

	private void WaterComeUp(){
		var lerpY = Mathf.Lerp(water.transform.position.y, 5, Time.deltaTime * 2);
		water.transform.position = transform.position + (Vector3.one * lerpY);
	}

	private IEnumerator DelayChange(float time){
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(nextScenceName);

	}
}