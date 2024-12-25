using System;

public interface IStateACondition : IConditional, IBooleanCondition
{
    public bool IsConditionMet();
}

