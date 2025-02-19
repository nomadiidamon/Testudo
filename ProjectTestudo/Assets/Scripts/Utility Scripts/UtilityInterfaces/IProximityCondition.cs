using UnityEngine;

public interface IProximityCondition : IStateACondition
{
    float GetDistance();
    object GetTarget();
}