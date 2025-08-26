using System;
using System.Collections.Generic;
using UnityEngine;

public class RoundTimer : MonoBehaviour
{
    [SerializeField] private float roundDuration = 60f; // 1 minute
    private float timeRemaining;
    private static bool isRunning;
    
    public HealthBar timerBar;

    public static event Action<float> OnTimeChanged;   // sends remaining time
    public static event Action OnRoundEnd;             // round finished

    private void OnEnable()
    {
        StartRound();
    }

    public void StartRound()
    {
        timeRemaining = roundDuration;
        isRunning = true;
        timerBar.SetMaxHealth((int) roundDuration);
        timerBar.SetHealth((int)timeRemaining);
        // timerBar.SetHealth((int)(timeRemaining/ roundDuration) * 100);
    }

    public static void StopRound()
    {
        StopTimer();
        OnRoundEnd?.Invoke();
    }

    private void Update()
    {
        if (!isRunning) return;
        timeRemaining -= Time.deltaTime;
    
        timerBar.SetHealth((int)timeRemaining);
        OnTimeChanged?.Invoke((float)Math.Round(timeRemaining, 1));

        if (timeRemaining <= 0f)
        {
            isRunning = false;
            timeRemaining = 0f;
            OnRoundEnd?.Invoke();
        }
    }

    public static void StopTimer()
    {
        isRunning = false;
    }
    public static bool IsRunning()
    {
        return isRunning;
    }
}
