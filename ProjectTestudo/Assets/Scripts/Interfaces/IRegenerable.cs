using System;

public interface IRegenerable
{
    void Tick(float time);
    bool isRegenerating { get; set; }
}
