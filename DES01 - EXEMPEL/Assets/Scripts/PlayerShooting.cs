using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;

    bool isFiring;

    void Start()
    {

    }

    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void Fire()
    {
        if (isFiring)
        {
            GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.Euler(0, 0, transform.localScale.x >= 0 ? 0 : 180));
        }
            
    }

    void Update()
    {
        Fire();
    }
}
