using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour, IObserver
{
    [SerializeField] private List<ObservableSubject> _subjects;
    
    protected Dictionary<ObservableActions, System.Action> _actionHandlers;

    public virtual void OnNotify(ObservableActions action)
    {
        if (_actionHandlers.ContainsKey(action))
        {
            _actionHandlers[action]();
        }
    }
    
    public virtual void OnEnable()
    {
        _subjects.ForEach((_subject) =>
        {
            _subject.AddObserver(this);
        });
    }

    public virtual void OnDisable()
    {
        _subjects.ForEach((_subject) =>
        {
            _subject.RemoveObserver(this);
        });
    }
}