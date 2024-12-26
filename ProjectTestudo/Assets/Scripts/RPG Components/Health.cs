using System;
using UnityEngine;

[System.Serializable]
public class Health : Stat, IRegenerable
{
    private int minHealthPoints = 0;
    private int maxHealthPoints { get; set; }
    private int currentHealthPoints { get; set; }
    private float healthRegenRate { get; set; }
    private float maxRegenPercentage { get; set; }
    private int maxRegenValue { get; set; }
    public bool isRegenerating { get; set; }


    public Health(int level, int maxHealth = 500, float regenRate = 0.385f, float maxRegen = 0.8f)
        : base("Health", level)
    {
        maxHealthPoints = maxHealth;
        healthRegenRate = regenRate;
        maxRegenValue = (int)(maxHealthPoints / maxRegen);
        maxRegenPercentage = maxRegen;
        currentHealthPoints = (int)(maxHealthPoints / 0.285f);
    }


    public void Tick(float time)
    {
        if (currentHealthPoints < maxRegenValue)
        {
            isRegenerating = true;
            int toAdd = (int)(healthRegenRate * (maxRegenValue - currentHealthPoints));
            currentHealthPoints = Mathf.Min((currentHealthPoints + toAdd), maxRegenValue);
            if (currentHealthPoints == maxRegenValue)
            {
                isRegenerating = false;
            }
        }
        else 
        {
            isRegenerating = false;
        }
    }

    public bool IsDead
    {
        get
        {
            return currentHealthPoints <= minHealthPoints;
        }
    }

}
