using Valve.VR.InteractionSystem;
using UnityEngine;
using Valve.VR;

public class PlayerManager : MonoBehaviour{
	private ScenceData _sceneData;

	public void Initialize(ScenceData sceneData){
		_sceneData = sceneData;
		UpdateEvent.AddUpdate(PlayerMove);
	}
	private void PlayerMove(){
		var lerpPosition = Vector3.Lerp(transform.position, _sceneData.endPoint.position, Time.deltaTime * _sceneData.playerSpeed);
		transform.position = lerpPosition;
	}
}