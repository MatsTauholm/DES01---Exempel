using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletShell;
    [SerializeField] private GameObject gun;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private AudioClip shoot;

    private float gunAngle;
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
        RotateGunToMouse();
        if (isFiring && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void RotateGunToMouse()
    {
        // Get mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate direction from gun to mouse
        Vector2 direction = (mousePosition - gun.transform.position).normalized;

        // Calculate angle in degrees
        gunAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation to the gun
        gun.transform.rotation = Quaternion.Euler(0f, 0f, gunAngle);
    }


    void Fire()
    {
        if (isFiring)
        {
            gunKickback.PlayKickback();
            AudioManager.PlaySound(shoot);
            GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.Euler(0, 0, transform.localScale.x >= 0 ? 0 : 180));
            GameObject newbulletShell = Instantiate(bulletShell, gun.transform.position, gun.transform.rotation);
        }           
    }


}
