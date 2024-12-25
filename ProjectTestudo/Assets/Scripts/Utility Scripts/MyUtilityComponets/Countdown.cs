using System;

public class Countdown : Timer
{

    public void StartCountdown()
    {
        StartTimer(0);
    }
    public void StopCountdown()
    {
        StopTimer();
    }
    public void PauseCountdown()
    {
        PauseTimer();
    }
    public void ResumeCountdown()
    {
        ResumeTimer();
    }
    public void UpdateCountdown()
    {
        UpdateTimer();
    }
    public void ResetCountdown()
    {
        StartTimer(0);
    }
    public void RestartCountdown()
    {
        StartTimer(0);
    }
    public void LapCountdown()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void SplitCountdown()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void UnsplitCountdown()
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
    public void SetCountdown()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetCountdown()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetCountdownTime()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetCountdownTimeRemaining()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetCountdownTimeElapsed()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetCountdownTimeTotal()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetCountdownTimeRemainingTotal()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetCountdownTimeElapsedTotal()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }
    public void GetCountdownTimeTotalTotal()
    {
        elapsedTime = 0;
        elapsedTimeRemaining = 0;
    }


}
