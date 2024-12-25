using System;
using UnityEngine;

[System.Serializable]
public class Timer : MonoBehaviour
{
    public bool isRunning = false;
    public bool isPaused = false;
    public bool isFinished = false;

    public float time = 0;
    public float currentTime = 0;
    public float timeRemaining = 0;
    public float elapsedTime = 0;
    public float elapsedTimeRemaining = 0;


    public void StartTimer(float _time)
    {
        time = _time;
        currentTime = time;
        timeRemaining = time;
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
        isRunning = true;
        isPaused = false;
        isFinished = false;
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }

    public void StopTimer()
    {
        isRunning = false;
        isPaused = false;
        isFinished = true;
    }

    public void UpdateTimer()
    {
        if (isRunning && !isPaused)
        {
            currentTime -= Time.deltaTime;
            elapsedTime += Time.deltaTime;
            timeRemaining = currentTime;
            elapsedTimeRemaining = elapsedTime;
            if (currentTime <= 0)
            {
                StopTimer();
            }
        }
    }

    public void ResetTimer()
    {
        currentTime = time;
        timeRemaining = time;
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
        isRunning = false;
        isPaused = false;
        isFinished = false;
    }

    public void SetTime(float _time)
    {
        time = _time;
        currentTime = time;
        timeRemaining = time;
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }

    public void AddTime(float _time)
    {
        time += _time;
        currentTime += _time;
        timeRemaining = currentTime;
    }

    public void SubtractTime(float _time)
    {
        time -= _time;
        currentTime -= _time;
        timeRemaining = currentTime;
    }



}
