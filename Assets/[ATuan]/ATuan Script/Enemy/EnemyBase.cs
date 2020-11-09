using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Animator))]
public abstract class EnemyBase : MonoBehaviour
{
    protected Animator EnemyAnimator;
    [SerializeField] private float failMaxDistance;
    public float moveSpeed;
    public SoundFile titleSoundFile;
    public GameObject anserObject;
    public float repeatTime;
    public bool pass;

    private void Awake()
    {
        anserObject.SetActive(false);
        StartCoroutine(TitleSound(repeatTime, titleSoundFile));
        EnemyAnimator = GetComponent<Animator>();
        UpdateEvent.AddUpdate(OnUpdate);
    }

    #region abstractfuntion

    protected abstract Vector3 TargetPosition { get; }
    protected abstract void Onhit();
    protected abstract void OnPass();

    protected abstract void OnFail();

    #endregion

    protected virtual void OnUpdate()
    {
        MoveToTarget(TargetPosition);
        TargetTrack(TargetPosition);
        PassTrack(pass);
    }

    private void TargetTrack(Vector3 targetPosiotion)
    {
        float distance = Vector3.Distance(transform.position, targetPosiotion);
        if (distance < failMaxDistance)
            OnFail();
    }

    private void PassTrack(bool ispass)
    {
        if (ispass)
            OnPass();
    }

    private void MoveToTarget(Vector3 targetPosition)
    {
        Vector3 finalPos = transform.position - targetPosition;
        transform.Translate(finalPos.normalized * moveSpeed);
    }

    private IEnumerator TitleSound(float second, SoundFile file)
    {
        // if (OnPass())
        //     yield break;
        yield return new WaitForSeconds(second);
        PlayerSound(file);
        StartCoroutine(TitleSound(second, file));
    }

    private void PlayerSound(SoundFile file)
    {
        ScenceData.Data.soundManager.PlaySound(file);
    }
}