using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    // Stats
    [Header("Stats")]
    [SerializeField] private EntityStats baseStats;

    // Movement
    [Header("READ ONLY - Movement Attributes")]
    [SerializeField] private Vector2 movementDirection;
    [SerializeField] private Vector2 smoothDirection;
    [SerializeField] private Vector2 smoothDirectionVelocity;
    
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {
        smoothDirection = Vector2.SmoothDamp(
            smoothDirection,
            movementDirection,
            ref smoothDirectionVelocity,
            baseStats.mass / baseStats.acceleration);
        
        rb.velocity = smoothDirection * baseStats.maxMoveSpeed;
    }

    #region Movement

    public void AddVelocity(Vector2 direction) => movementDirection = direction;
    
    #endregion
    
}
