using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] int maxHealth = 7;
    int currentHealth;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if health is depleted
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            // Destroy the bullet
            Destroy(collision.gameObject);

            // Enemy takes 1 damage
            TakeDamage(1);
        }
    }

}
