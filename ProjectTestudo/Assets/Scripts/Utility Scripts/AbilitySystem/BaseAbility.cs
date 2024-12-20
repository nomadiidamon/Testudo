using System;
using System.Collections.Generic;

public abstract class BaseAbility : IAbility
{
    public abstract string AbilityName { get; }
    public List<IStateCondition> Conditions { get; private set; }
    public bool isActive = false; // Tracks whether the ability is currently active
    public bool isReady = false; // Tracks whether the ability is ready to activate
    public bool IsEnabled { get; private set; } = true; // Tracks whether the ability is enabled

    public event Action OnAbilityActivated;
    public event Action OnAbilityDeactivated;



    protected BaseAbility()
    {
        Conditions = new List<IStateCondition>();
    }

    // Check whether or not the ability is active
    public bool CanActivate()
    {
        if (!IsEnabled) return false;
        
        foreach (var condition in Conditions)
        {
            if (!condition.IsConditionMet())
                return false;
        }
       
        return true;
    }
    // Activates the ability
    public abstract void Activate();
    
    // deactivates the ability
    public virtual void Deactivate()
    {
        if (!isActive) return;

        isActive = false;
        OnAbilityDeactivated?.Invoke();
    }
    
    // enables the use of the ability
    public void Enable()
    {
        if (IsEnabled) return;

        IsEnabled = true;
        OnEnable();
    }


    // disables the use of the ability
    public void Disable()
    {
        if (!IsEnabled) return;

        IsEnabled = false;
        OnDisable();
    }


    protected virtual void OnEnable()
    {
        Console.WriteLine($"{AbilityName} has been enabled.");
    }

    protected virtual void OnDisable()
    {
        Console.WriteLine($"{AbilityName} has been disabled.");
    }

}
