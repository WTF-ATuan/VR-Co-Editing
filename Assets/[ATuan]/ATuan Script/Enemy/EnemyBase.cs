using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using ATuan_Script.Extra;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public abstract class EnemyBase : MonoBehaviour
{
    protected Animator EnemyAnimator;
    private Rigidbody _enemyRigidbody;
    public LevelController levelController;
    public float failMaxDistance;
    public float moveSpeed;
    public SoundFile titleSoundFile;
    public float repeatTime;
    public CheckPoint thisLevelPoint;

    public bool Pass => levelController.Passing;

    private void Awake()
    {
        StartCoroutine(TitleSound(repeatTime, titleSoundFile));
        EnemyAnimator = GetComponent<Animator>();
        _enemyRigidbody = GetComponent<Rigidbody>();
        levelController = GetComponentInChildren<LevelController>();
        UpdateEvent.AddUpdate(OnUpdate);
    }

    #region abstractfuntion

    protected abstract Vector3 TargetPosition { get; }
    protected abstract void OnHit();

    protected virtual void OnPass(){
        thisLevelPoint.levelControl = true;
        CheckPointManager.instance.PassLevel();
    }

    protected abstract void OnFail();

    #endregion

    protected virtual void OnUpdate()
    {
        MoveToTarget(TargetPosition);
        TargetTrack(ScenceData.Data.player.transform.position);
        PassTrack();
    }

    private void TargetTrack(Vector3 targetPosition)
    {
        if (levelController.Passing)
            return;
        var distance = Vector3.Distance(transform.position, targetPosition);
        if (distance < failMaxDistance)
            OnFail();
    }

    private void PassTrack()
    {
        if(levelController.Passing){
            OnPass();
        }
    }

    private void MoveToTarget(Vector3 targetPosition)
    {
        var finalPos = targetPosition - transform.position;
        _enemyRigidbody.velocity = finalPos.normalized * moveSpeed;
    }

    private IEnumerator TitleSound(float second, SoundFile file)
    {
        if (levelController.Passing)
            yield break;
        yield return new WaitForSeconds(second);
        PlaySound(file);
        StartCoroutine(TitleSound(second, file));
    }

    private void PlaySound(SoundFile file)
    {
        ScenceData.Data.soundManager.PlaySound(file);
    }
}