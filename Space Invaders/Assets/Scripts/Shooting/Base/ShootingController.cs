using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    public void Shoot(Quaternion rotation)
    {
        GameObject discharge = Instantiate(bulletPrefab, firePoint.position, rotation);
    }
}
