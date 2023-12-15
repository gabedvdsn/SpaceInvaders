using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputObserver : Observer
{
    private void Awake()
    {
        _actionHandlers = new Dictionary<ObservableActions, Action>()
        {
            { ObservableActions.PlayerStartsMoving, OnPlayerStartsMoving },
            { ObservableActions.PlayerMoving, OnPlayerMoving },
            { ObservableActions.PlayerStopsMoving, OnPlayerStopsMoving }
        };
    }

    void OnPlayerStartsMoving()
    {
        // Debug.Log($"Started Moving");
    }

    void OnPlayerMoving()
    {
        // Debug.Log($"Is Moving");
    }

    void OnPlayerStopsMoving()
    {
        // Debug.Log($"Stopped Moving");
    }
}
