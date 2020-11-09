using Valve.VR.InteractionSystem;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private ScenceData scenceData;
    public void Initialize(ScenceData scenceData)
    {
        this.scenceData = scenceData;
        UpdateEvent.AddUpdate(OnUpdate);
    }
    public bool IsPlayerDied()
    {
        return scenceData.PlayerHp <= 0;
    }
    public void GetHit(int Damage) {
        scenceData.PlayerHp -= Damage;
    }
    public void Recovery(int Hp) {
        scenceData.PlayerHp += Hp;
    }
    public void MovePlayer(Vector3 TargetPosition) {
        scenceData.Player.transform.position = TargetPosition;
    }

    private void OnUpdate()
    {
        if (InputData.instance.HovingObject.gameObject == ScenceData.Data.BubbleGun)
        {
            if (InputData.instance.GripButton.active || InputData.instance.FireButton.active)
            {
                InputData.instance.Equip(InputData.instance.HovingObject , InputData.instance.HandTouch);
                UpdateEvent.RemoveUpdate(OnUpdate);
            }
        }
        
    }

}
