using System;
using UnityEngine;

public class Stamina : Stat, IRegenerable
{
    private int minStaminaPoints = 0;
    private int maxStaminaPoints { get; set; }
    private int currentStaminaPoints { get; set; }
    private float staminaRegenRate { get; set; }
    private float maxRegenPercentage { get; set; }
    private int maxRegenValue { get; set; }
    public bool isRegenerating { get; set; }  
    public bool isStunned { get; set; }

    Stamina(int level, int maxStamina = 500, float regenRate = 0.375f, float maxRegen = 0.8f)
        : base("Stamina", level)
    {
        maxStaminaPoints = maxStamina;
        staminaRegenRate = regenRate;
        maxRegenValue = (int)(maxStaminaPoints / maxRegen);
        maxRegenPercentage = maxRegen;
        currentStaminaPoints = (int)(maxStaminaPoints / 0.275f);
    }

    public void Tick(float time)
    {
        if (isRegenerating)
        {

            if (currentStaminaPoints < maxRegenValue)
            {
                isRegenerating = true;
                int toAdd = (int)(staminaRegenRate * (maxRegenValue - currentStaminaPoints));
                currentStaminaPoints = Mathf.Min((currentStaminaPoints + toAdd), maxRegenValue);
                if (currentStaminaPoints == maxRegenValue)
                {
                    isRegenerating = false;
                }
            }
            else
            {
                isRegenerating = false;
            }
        }
    }

    private bool TryToSpendStamina(int amount)
    {
        if (currentStaminaPoints >= amount)
        {
            currentStaminaPoints -= amount;
            return true;
        }
        return false;
    }

    public bool UseStamina(int amount)
    {
        if (TryToSpendStamina(amount))
        {
            return true;
        }
        else
        {
            isStunned = true;
            Stun(CalculateStunTime(amount));
            return false;

        }
    }

    public bool Stun(float time = 0.475f)
    {
        isStunned = true;
        // Stun the player for a certain amount of time, then return to normal
        // possibly change the parameter to an Action or Func delegate
        isStunned = false;

        return true;
    }

    private float  CalculateStunTime(int amount)
    {
        return amount * 0.475f;
    }


}

