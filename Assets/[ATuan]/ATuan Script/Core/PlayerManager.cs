using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private ScenceData scenceData;
    public void Initialize(ScenceData scenceData)
    {
        this.scenceData = scenceData;
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
}
