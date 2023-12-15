using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Stats
    [SerializeField] private EntityStats baseStats;

    // Movement
    [SerializeField] private Vector2 movementDirection;
    [SerializeField] private Vector2 smoothDirection;
    [SerializeField] private Vector2 smoothDirectionVelocity;
    
    // Components
    private Animator anim;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    
    #region Getters
    public virtual Entity Get() => this;
    public Animator GetAnim() => anim;
    public Rigidbody2D GetRB() => rb;
    #endregion
}
