using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableSubject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    protected void NotifyObservers(ObservableActions actions)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(actions);
        });
    }
}
