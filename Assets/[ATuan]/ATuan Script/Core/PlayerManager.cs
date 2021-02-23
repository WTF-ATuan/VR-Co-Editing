using Valve.VR.InteractionSystem;
using UnityEngine;
using Valve.VR;

public class PlayerManager : MonoBehaviour
{
    private ScenceData sceneData;

    public void Initialize(ScenceData sceneData)
    {
        this.sceneData = sceneData;
        UpdateEvent.AddUpdate(OnUpdate);
    }

    public bool IsPlayerDied()
    {
        return sceneData.PlayerHp <= 0;
    }

    public void GetHit(int Damage)
    {
        sceneData.PlayerHp -= Damage;
    }

    public void Recovery(int Hp)
    {
        sceneData.PlayerHp += Hp;
    }

    public void MovePlayer(Vector3 TargetPosition)
    {
        sceneData.Player.transform.position = TargetPosition;
    }

    private void OnUpdate()
    {
        MoveForward(ScenceData.Data.Boat);
        if (InputData.instance.HoveringObject != null)
        {
            if (InputData.instance.HoveringObject.gameObject == ScenceData.Data.LoudGun)
            {
                if (InputData.instance.GripAction)
                {
                    InputData.instance.Equip(InputData.instance.HoveringObject, InputData.instance.hand);
                    UpdateEvent.RemoveUpdate(OnUpdate);
                }
            }
        }
    }

    private void MoveForward(GameObject boat)
    {
       boat.transform.Translate(-boat.transform.forward * ScenceData.Data.playerSpeed);
    }
}