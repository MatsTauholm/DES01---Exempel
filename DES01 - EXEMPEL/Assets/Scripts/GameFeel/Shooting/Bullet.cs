using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IMechanic
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float spreadAngle = 0f;
    [SerializeField] int damageAmount;
    Rigidbody2D rb;

    public bool IsEnabled { get; private set; } = true;

    public void Enable()
    {
        IsEnabled = true;
        // Activate logic
    }

    public void Disable()
    {
        IsEnabled = false;
        // Deactivate logic
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        var effects = EffectManager.Instance;
        
        // Apply random spread angle
        float randomSpread = Random.Range(-spreadAngle, spreadAngle);
        Quaternion spreadRotation = Quaternion.Euler(0f, 0f, randomSpread);
        Vector2 spreadDirection = spreadRotation * transform.right;

        // Set the velocity
        rb.linearVelocity = spreadDirection * bulletSpeed;
    }

    void Update()
    {
        rb.linearVelocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemyBehavior))
        {
            enemyBehavior.TakeDamage(damageAmount, transform.right);
        }
        Destroy(gameObject);
    }
}
