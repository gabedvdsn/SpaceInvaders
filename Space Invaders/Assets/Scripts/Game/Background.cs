using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float parallaxCoefficient;

    private Transform cam;
    private Vector2 position;
    private Vector2 distanceMoved;
    private float width, height;

    private void Start()
    {
        if (Camera.main != null) cam = Camera.main.transform;

        position = transform.position;
        
        width = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        height = GetComponentInChildren<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        DoParallaxMovement();
        DoPositionCheck();
    }

    private void DoParallaxMovement()
    {
        distanceMoved = cam.position * (1 - parallaxCoefficient);
        Vector2 distanceToMove = cam.position * parallaxCoefficient;

        transform.position = new Vector3(distanceToMove.x, distanceToMove.y);
    }

    private void DoPositionCheck()
    {
        if (distanceMoved.x > position.x + width)
        {
            position.x += width;
        }
        else if (distanceMoved.x < position.x - width)
        {
            position.x -= width;
        }
        
        if (distanceMoved.y > position.y + height)
        {
            position.y += height;
        }
        else if (distanceMoved.y < position.y + height)
        {
            position.y -= height;
        }
    }
}
