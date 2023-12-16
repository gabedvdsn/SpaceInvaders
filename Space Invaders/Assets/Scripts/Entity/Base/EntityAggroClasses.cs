using System;
using System.Collections.Generic;

public enum GameElementClassification
{
    Any,
    None,
    Structure,
    Ship,
    Bullet
}

public enum EntityAffiliation
{
    Any,
    None,
    Ally,
    Enemy
}

public static class EntityAggroDefaults
{
    private static readonly Dictionary<GameElementClassification, float> classificationToAggro = new Dictionary<GameElementClassification, float>()
    {
        { GameElementClassification.Any, .1f },
        { GameElementClassification.None, 0f },
        { GameElementClassification.Ship, .5f },
        { GameElementClassification.Structure, 1.5f },
        { GameElementClassification.Bullet, .3f }
    };

    public static float FromClassification(GameElementClassification classification) => classificationToAggro.GetValueOrDefault(classification);
}