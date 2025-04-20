public class Stopwatch : Timer
{
    public void StartStopwatch() => StartTimer(0);
    public void ResetStopwatch() => ResetTimer();
    public void RestartStopwatch() => StartStopwatch();
}
