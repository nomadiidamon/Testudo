using System;
using System.Collections.Generic;


public interface IAbility
{
    string AbilityName { get; }
    List<IStateCondition> Conditions { get; }

    void Activate();
    void Deactivate();
    bool CanActivate();
}
