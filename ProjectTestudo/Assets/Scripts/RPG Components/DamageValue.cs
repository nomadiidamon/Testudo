using System;
using System.Collections.Generic;

[System.Serializable]
public class DamageValue
{
    public DamageType type { get; set; }
    public int damageAmount { get; set; }

    DamageValue(DamageType type, int damageAmount)
    {
        this.type = type;
        this.damageAmount = damageAmount;
    }

}
