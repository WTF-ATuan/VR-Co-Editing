using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public abstract class EnemyBase : MonoBehaviour
{
    protected Animator EnemyAnimator;
    private Rigidbody enemyRigidbody;
    public LevelCollector levelCollector;
    public float failMaxDistance;
    public float moveSpeed;
    public SoundFile titleSoundFile;
    public GameObject answerObject;
    public float repeatTime;
    public LevelSet thisLevelSet;


    private void Awake()
    {
        answerObject.SetActive(false);
        StartCoroutine(TitleSound(repeatTime, titleSoundFile));
        EnemyAnimator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody>();
        levelCollector = GetComponentInChildren<LevelCollector>();
        UpdateEvent.AddUpdate(OnUpdate);
    }

    #region abstractfuntion

    protected abstract Vector3 TargetPosition { get; }
    protected abstract void OnHit();
    protected abstract void OnPass();

    protected abstract void OnFail();

    #endregion

    protected virtual void OnUpdate()
    {
        MoveToTarget(TargetPosition);
        TargetTrack(ScenceData.Data.Player.transform.position);
        PassTrack();
    }

    private void TargetTrack(Vector3 targetPosition)
    {
        if (levelCollector.passing)
            return;
        var distance = Vector3.Distance(transform.position, targetPosition);
        if (distance < failMaxDistance)
            OnFail();
    }

    private void PassTrack()
    {
        if (!levelCollector.passing) return;
        answerObject.SetActive(true);
        OnPass();
    }

    private void MoveToTarget(Vector3 targetPosition)
    {
        var finalPos = targetPosition - transform.position;
        enemyRigidbody.velocity = finalPos.normalized * moveSpeed;
    }

    private IEnumerator TitleSound(float second, SoundFile file)
    {
        if (levelCollector.passing)
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