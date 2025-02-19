using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable
{
    void AddObserver();
    void RemoveObserver();
    void NotifyObservers();
}
