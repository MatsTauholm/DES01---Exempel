using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] int damageAmount;
    Rigidbody2D rb;
    
 
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
