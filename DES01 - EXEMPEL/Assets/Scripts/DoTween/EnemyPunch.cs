using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPunch : MonoBehaviour
{
    [SerializeField] Transform player;        // Reference to the player
    [SerializeField] float moveSpeed = 3f;    // Movement speed of the enemy
    [SerializeField] float stopDistance = 2f; // Distance to stop and punch
    [SerializeField] float punchPower = 0.5f; // Strength of the punch
    [SerializeField] float punchDuration = 0.3f; // Duration of the punch

    Vector3 direction;
    private bool isPunching = false;

    void Update()
    {
        if (player == null) return; // Exit if player is not assigned

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

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
        direction = (player.position - transform.position).normalized;
    }

    void FollowPlayer()
    {
        direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.LookAt(player); // Optional: Make the enemy face the player
    }

    void StartPunch()
    {
        isPunching = true;

        // Punch effect using DoTween
        transform.DOPunchPosition(direction * punchPower, punchDuration, 10, 1f)
            .OnComplete(() => isPunching = false); // Reset punching flag after animation
    }
}
