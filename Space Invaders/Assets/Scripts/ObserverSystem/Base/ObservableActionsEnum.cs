using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObservableActions
{
    // Responding to in-game player interactions
    PlayerTakesDamage,
    PlayerFires,
    PlayerDies,
    
    // Responding to player input
    PlayerStartsMoving,
    PlayerMoving,
    PlayerStopsMoving,
    
    // Responding to in-game enemy interactions
    EnemyTakesDamage,
    EnemyFires,
    EnemyDies
}