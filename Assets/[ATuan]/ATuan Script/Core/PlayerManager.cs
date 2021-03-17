using ATuan_Script.Extra;
using Valve.VR.InteractionSystem;
using UnityEngine;
using Valve.VR;

public class PlayerManager : MonoBehaviour{
	[SerializeField] private float speed;
	[SerializeField] private GameObject ship;
	private void Update(){
		CheckPointManager.instance.MoveToTarget(transform , speed , ship);
	}
}