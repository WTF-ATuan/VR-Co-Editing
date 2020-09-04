using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MineData;
using System;

public class Timer {
    public float copyRemainingSeconds;
    public float remainingSeconds;
    public Timer(float duringTime)
    {
        remainingSeconds = duringTime;
        copyRemainingSeconds = duringTime;
    }
    public bool IsTimerEnd = false;
    public void Tick(float deltaTime)
    {
        if (remainingSeconds == 0f) { return; }

        remainingSeconds -= deltaTime;
        CheckForTimerEnd();
    }
    public void CheckForTimerEnd()
    {
        if (remainingSeconds > 0) { return; }

        remainingSeconds = 0f;

        IsTimerEnd = true;
    }
    public void RestTimer() {
        remainingSeconds = copyRemainingSeconds;
        IsTimerEnd = false;
    }
}
