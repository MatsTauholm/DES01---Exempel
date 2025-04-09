using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPunch : MonoBehaviour
{
    [SerializeField] Transform player;        // Reference to the player
    [SerializeField] GameObject fist;        // Reference to the fist
    [SerializeField] float moveSpeed = 3f;    // Movement speed of the enemy
    [SerializeField] float stopDistance = 2f; // Distance to stop and punch
    [SerializeField] float punchPower = 0.5f; // Strength of the punch
    [SerializeField] float punchDuration = 0.3f; // Duration of the punch
    [SerializeField] float punchElasticity = 0.3f; // Elasticity of the punch
    [SerializeField] int punchVibrato = 1; // Vibration of the punch

    Vector3 direction;
    private bool isPunching = false;

    void Update()
    {
        
        if (player == null) return; // Exit if player is not assigned

        direction = (player.position - transform.position).normalized; //Find the direction from the player to the enemy
        float distanceToPlayer = Vector2.Distance(transform.position, player.position); //Check distance

        if (distanceToPlayer > stopDistance)
        {
            FollowPlayer();
        }
        else
        {
            if (!isPunching)
            {
                StartPunch();
            }
        }
        
    }

    void FollowPlayer()
    {
        //direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Compare x positions
        if (player.position.x > transform.position.x)
        {
            // Player is to the right: face right
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            // Player is to the left: face left
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void StartPunch()
    {
        isPunching = true;

        // Punch effect using DoTween
        fist.transform.DOPunchPosition(direction * punchPower, punchDuration, punchVibrato, punchElasticity)
            .OnComplete(() => isPunching = false); // Reset punching flag after animation
    }
}
