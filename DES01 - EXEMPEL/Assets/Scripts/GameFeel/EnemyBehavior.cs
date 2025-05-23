using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] int maxHealth = 7;
    int currentHealth;
    Rigidbody2D rb;
    private KnockBack knockback;
    TimeFreezer timeFreezer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knockback = GetComponent<KnockBack>();
    }


    void Start()
    {
        currentHealth = maxHealth;
        timeFreezer = FindObjectOfType<TimeFreezer>();
    }

    void Update()
    {
        if(!knockback.isBeingKnockedBack)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        
    }

    public void TakeDamage(int damage, Vector2 hitDirection)
    {
        currentHealth -= damage;
        // Check if health is depleted
        if (currentHealth <= 0)
        {
            timeFreezer.Freeze();
            Destroy(gameObject);
        }

        //Apply knockback
        knockback.CallKnockBack(hitDirection, Vector2.up, 0f);
    }
}
