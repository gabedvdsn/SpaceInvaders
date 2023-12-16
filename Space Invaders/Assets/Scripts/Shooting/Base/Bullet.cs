using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Entity
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifetime;
    [SerializeField] private LayerMask whatDestroysBullet;

    private Entity sourceEntity;
    
    public override void Start()
    {
        base.Start();
        
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        
        rb.velocity = -transform.up * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((whatDestroysBullet.value & (1 << other.gameObject.layer)) > 0)
        {
            // particles
            
            // fx
            
            // screen shake
            
            // object interactions
            
            // destroy
            Destroy(gameObject);
        }
    }

    public void SetSourceEntity(Entity entity)
    {
        sourceEntity = entity;
        affiliation = entity.GetAffiliation();
    }
    
    public override Entity Get() => sourceEntity;
}
