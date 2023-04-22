using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float biteAttackRange = 6f;
    public float poisonAttackRange = 19f;
    public float attackDelay = 3f;
    public float attackDuration = 1f;
    public float returnDelay = 2f;
    public GameObject projectile;
    public GameObject mortarProjectile;
    private float attackTimer;
    private float returnTimer;
    private bool attacking;
    private bool returning;
    private Vector2 originalPosition;
    private Vector2 lastKnownPlayerPosition;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object
        originalPosition = transform.position; // Save the boss's original position
        lastKnownPlayerPosition = player.position; // Initialize the last known player position to the player's current position
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking && !returning)
        {
            // Check if the player is within range of the boss
            if (IsPlayerInBiteRange())
            {
                // Save the player's current position as the last known player position
                lastKnownPlayerPosition = player.position;

                // Set the attack timer and start the attack behavior
                attackTimer = Time.time + attackDelay;
                attacking = true;
                StartCoroutine(BiteAttack());
            }
            // Check if the player is within range of the boss
            if (IsPlayerInShootingRange())
            {
                // Save the player's current position as the last known player position
                lastKnownPlayerPosition = player.position;

                // Set the attack timer and start the attack behavior
                attackTimer = Time.time + attackDelay;
                attacking = true;
                if (Random.Range(0, 2) == 0)
                {
                    StartCoroutine(ShootAttack());
                }
                else
                {
                    StartCoroutine(MortarAttack());
                }
            }
        }
        else if (returning)
        {
            // Move the boss towards its original position
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);

            // Check if the boss has returned to its original position
            if (Vector2.Distance(transform.position, originalPosition) < 0.1f)
            {
                // Reset the timers and flags
                attacking = false;
                returning = false;
            }
        }
    }

    IEnumerator BiteAttack()
    {
        // Move the boss towards the last known player position and start the attack animation
        while (Time.time < attackTimer + attackDuration)
        {
            transform.position = Vector2.MoveTowards(transform.position, lastKnownPlayerPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Set the return timer and start returning to the original position
        returnTimer = Time.time + returnDelay;
        attacking = false;
        returning = true;
    }

    IEnumerator ShootAttack()
    {
        int numShots = 0;
        while (numShots < 3)
        {
            Instantiate(projectile, originalPosition, Quaternion.identity);
            numShots++;
            yield return new WaitForSeconds(1f); // Add a delay between each shot
        }

        // Set the return timer and start returning to the original position
        returnTimer = Time.time + returnDelay;
        attacking = false;
        returning = true;
    }

    IEnumerator MortarAttack()
    {
        // Instantiate a mortar projectile at a random position above the boss
        Vector2 mortarSpawnPosition = new Vector2(lastKnownPlayerPosition.x, lastKnownPlayerPosition.y + 5f);
        Instantiate(mortarProjectile, mortarSpawnPosition, Quaternion.identity);

        // Wait for a short duration before firing the next projectile
        yield return new WaitForSeconds(4f);

        // Repeat for a total of 3 projectiles
        for (int i = 0; i < 2; i++)
        {
            mortarSpawnPosition = new Vector2(lastKnownPlayerPosition.x - (i * 3f), lastKnownPlayerPosition.y + 5f);
            Instantiate(mortarProjectile, mortarSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

        // Set the return timer and start returning to the original position
        returnTimer = Time.time + returnDelay;
        attacking = false;
        returning = true;
    }


    private bool IsPlayerInBiteRange()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, biteAttackRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsPlayerInShootingRange()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, poisonAttackRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                if (!IsPlayerInBiteRange()) // Check if the player is not also in bite range
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, biteAttackRange);
        Gizmos.DrawWireSphere(transform.position, poisonAttackRange);
    }
}
