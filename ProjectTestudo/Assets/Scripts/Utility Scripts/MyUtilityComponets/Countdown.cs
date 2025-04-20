public class Countdown : Timer
{
    public void StartCountdown(float duration) => StartTimer(duration);
    public void ResetCountdown() => ResetTimer();
    public void RestartCountdown(float duration) => StartCountdown(duration);
}
