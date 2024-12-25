using System;

public class Stopwatch : Timer
{

    public void StartStopwatch()
    {
        StartTimer(0);
    }
    public void StopStopwatch()
    {
        StopTimer();
    }
    public void PauseStopwatch()
    {
        PauseTimer();
    }
    public void ResumeStopwatch()
    {
        ResumeTimer();
    }
    public void UpdateStopwatch()
    {
        UpdateTimer();
    }
    public void ResetStopwatch()
    {
        StartTimer(0);
    }
    public void RestartStopwatch()
    {
        StartTimer(0);
    }
    public void LapStopwatch()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void SplitStopwatch()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void UnsplitStopwatch()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetLapTime()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetSplitTime()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetUnsplitTime()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetElapsedTime()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetElapsedTimeRemaining()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetTime()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetTimeRemaining()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetTimeElapsed()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetTimeElapsedRemaining()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetTimeRemainingElapsed()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetTimeRemainingElapsedRemaining()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetTimeElapsedRemainingElapsed()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetTimeElapsedRemainingElapsedRemaining()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;


    }
}
