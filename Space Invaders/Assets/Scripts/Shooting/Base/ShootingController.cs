using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    
    [SerializeField] private Entity parentEntity;

    private void Start()
    {
        // parentEntity = GetComponent<Entity>();
    }

    public void Shoot(Quaternion rotation)
    {
        GameObject discharge = Instantiate(bulletPrefab, firePoint.position, rotation);
        discharge.GetComponent<Bullet>().SetSourceEntity(parentEntity);
    }
}
