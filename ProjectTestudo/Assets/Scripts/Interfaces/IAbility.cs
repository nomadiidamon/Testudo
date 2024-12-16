using System;

public interface IAbility
{
    string AbilityName { get; }
    List<IStateCondition> Conditions { get; }

    void Activate();
    void Deactivate();
    bool CanActivate();
}
