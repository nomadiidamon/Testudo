using UnityEngine;

public interface IThresholdCondition : IStateACondition
{
    float GetThresholdValue();
    float GetCurrentValue();
}

