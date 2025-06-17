using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletShell;
    [SerializeField] GameObject gun;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float fireRate = 0.2f;

    private float nextFireTime = 0f;
    private bool isFiring;

    private GunKickback gunKickback;
    private PlayerInput playerInput;
    private InputAction fireAction;

    void Awake()
    {
        gunKickback = FindFirstObjectByType<GunKickback>();
        playerInput = GetComponent<PlayerInput>();
        fireAction = playerInput.actions["Fire"];
    }

    void OnEnable()
    {
        fireAction.performed += StartFiring;
        fireAction.canceled += StopFiring;
    }

    void OnDisable()
    {
        fireAction.performed -= StartFiring;
        fireAction.canceled -= StopFiring;
    }

    private void StartFiring(InputAction.CallbackContext context)
    {
        isFiring = true;
    }

    private void StopFiring(InputAction.CallbackContext context)
    {
        isFiring = false;
    }

    void Update()
    {
        if (isFiring && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        if (isFiring)
        {
            gunKickback.PlayKickback();
            GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.Euler(0, 0, transform.localScale.x >= 0 ? 0 : 180));
            GameObject newbulletShell = Instantiate(bulletShell, gun.transform.position, Quaternion.identity);
        }           
    }


}
