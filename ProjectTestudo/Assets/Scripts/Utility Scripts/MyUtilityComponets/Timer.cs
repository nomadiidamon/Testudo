using UnityEngine;

[System.Serializable]
public class Timer : MonoBehaviour
{
    public bool isRunning { get; private set; }
    public bool isPaused { get; private set; }
    public bool isFinished { get; private set; }

    public float time { get; private set; }
    public float currentTime { get; private set; }
    public float elapsedTime { get; private set; }

    public void StartTimer(float _time)
    {
        time = _time;
        currentTime = time;
        elapsedTime = 0;
        isRunning = true;
        isPaused = false;
        isFinished = false;
    }

    public void PauseTimer() => isPaused = true;
    public void ResumeTimer() => isPaused = false;
    public void StopTimer()
    {
        isRunning = false;
        isPaused = false;
        isFinished = true;
    }

    public void ResetTimer()
    {
        currentTime = time;
        elapsedTime = 0;
        isRunning = false;
        isPaused = false;
        isFinished = false;
    }

    public void UpdateTimer()
    {
        if (isRunning && !isPaused)
        {
            currentTime -= Time.deltaTime;
            elapsedTime += Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                StopTimer();
            }
        }
    }

    public void AddTime(float _time)
    {
        time += _time;
        currentTime += _time;
    }

    public void SubtractTime(float _time)
    {
        time = Mathf.Max(0, time - _time);
        currentTime = Mathf.Max(0, currentTime - _time);
    }

    public float GetTimeRemaining() => currentTime;
    public float GetElapsedTime() => elapsedTime;
    public float GetTotalTime() => time;
}
