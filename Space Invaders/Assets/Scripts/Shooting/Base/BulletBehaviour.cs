using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifetime;
    [SerializeField] private LayerMask whatDestroysBullet;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void OnShoot()
    {
        // GetComponent<Rigidbody2D>().velocity = Vector2. * transform.eulerAngles * bulletSpeed;
    }
    
    public void OnHit()
    {
        throw new System.NotImplementedException();
    }
    
    public void OnDestroy()
    {
        
    }
}
