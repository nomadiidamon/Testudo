using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDealDamage
{
    public List<DamageValue> totalDamage { get; set; }
    void DealDamage(IHaveHealth damagable);
}

