using System;

public interface IStunnable
{

    void Stun(float time);
    bool isStunned { get; set; }
}
