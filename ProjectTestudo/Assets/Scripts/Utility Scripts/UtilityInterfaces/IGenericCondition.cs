using System;

public interface IGenericCondition<T> : IStateACondition
{
    T GetValue();
    bool Compare(T value);
}