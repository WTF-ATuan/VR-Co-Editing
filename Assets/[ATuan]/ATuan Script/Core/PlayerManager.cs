using Valve.VR.InteractionSystem;
using UnityEngine;
using Valve.VR;

public class PlayerManager : MonoBehaviour{
	private ScenceData _sceneData;

	public void Initialize(ScenceData sceneData){
		_sceneData = sceneData;
		InputData.instance.Equip(_sceneData.loudGun.GetComponent<Interactable>());
		UpdateEvent.AddUpdate(PlayerMove);
	}

	public bool IsPlayerDied(){
		return _sceneData.playerHp <= 0;
	}

	public void GetHit(int damage){
		_sceneData.playerHp -= damage;
	}

	public void Recovery(int hp){
		_sceneData.playerHp += hp;
	}
	
	private void PlayerMove(){
		var lerpPosition = Vector3.Lerp(transform.position, _sceneData.endPoint.position, Time.deltaTime * _sceneData.playerSpeed);
		transform.position = lerpPosition;
	}
}