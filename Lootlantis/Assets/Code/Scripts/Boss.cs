using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    public float biteAttackRange = 6f;
    public float poisonAttackRange = 19f;
    public float attackDelay = 3f;
    public float attackDuration = 1f;
    public float returnDelay = 2f;
    public GameObject projectile;
    public GameObject mortarProjectile;
    public float hitPoints;
    public float maxHitPoints = 1000;
    public HealthBarBehavior healthBar;
    private float attackTimer;
    private float returnTimer;
    private bool attacking;
    private bool returning;
    private Vector2 originalPosition;
    private Vector2 lastKnownPlayerPosition;

    //Added by Michael
    public AudioSource aud;
    public AudioClip audPlayerHit;
    public AudioClip enemyHit;
    public AudioClip spray;
    public float laserTick;
    public float laserPower;
    public Vector2 targetPosition;
    public float targetRotation;


    public int numberOfShootingAttack = 5;
  

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        player = GameObject.Find("Player"); // Find the player object
        originalPosition = transform.position; // Save the boss's original position
        lastKnownPlayerPosition = player.transform.position; // Initialize the last known player position to the player's current position
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking && !returning)
        {
            if (numberOfShootingAttack > 0) // Only attack if there are remaining shooting attacks
            {
                // Check if the player is within range of the boss
                if (IsPlayerInBiteRange())
                {
                    // Save the player's current position as the last known player position
                    lastKnownPlayerPosition = player.transform.position;

                    // Set the attack timer and start the attack behavior
                    attackTimer = Time.time + attackDelay;
                    attacking = true;
                    StartCoroutine(BiteAttack());
                }
                // Check if the player is within range of the boss
                else if (IsPlayerInShootingRange())
                {
                    // Save the player's current position as the last known player position
                    lastKnownPlayerPosition = player.transform.position;

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
            else // Move the boss's head diagonally if no shooting attacks are remaining
            {
        
                 
                // Move towards the target position
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, (moveSpeed * 5f) * Time.deltaTime);

                // Rotate towards the target rotation
                Quaternion targetQuaternion = Quaternion.Euler(0f, 0f, targetRotation);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, 100f * Time.deltaTime);
                Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
                // Check if the boss has reached the target position
                if (position2D == targetPosition)
                {
                  transform.position = new Vector3(0f, 23f, 0f);
                  transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                  numberOfShootingAttack = 5; // Reset the shooting attacks counter
                        
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
            aud.PlayOneShot(spray);
            Instantiate(projectile, originalPosition, Quaternion.identity);
            numShots++;
            yield return new WaitForSeconds(1f); // Add a delay between each shot
        }
        numberOfShootingAttack--;

        if (numberOfShootingAttack == 0)
        {
            chooseSide();
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
        yield return new WaitForSeconds(1f);

        // Repeat for a total of 3 projectiles
        for (int i = 0; i < 2; i++)
        {
            mortarSpawnPosition = new Vector2(lastKnownPlayerPosition.x - (i * 3f), lastKnownPlayerPosition.y + 5f);
            Instantiate(mortarProjectile, mortarSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        numberOfShootingAttack--;

        if (numberOfShootingAttack == 0)
        {
            chooseSide();
        }
        // Set the return timer and start returning to the original position
        returnTimer = Time.time + returnDelay;
        attacking = false;
        returning = true;
    }

    private void chooseSide()
    {
        if (Random.Range(0, 2) == 0)
        {
            targetPosition = new Vector2(-35f, -23f);
            targetRotation = -37.509f;
        }
        else
        {
            targetPosition = new Vector2(36f, -19f);
            targetRotation = 41f;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            aud.PlayOneShot(audPlayerHit);
            collision.gameObject.GetComponent<Player>().TakeDamage(5);
            //StartCoroutine(FlashAfterDamage());

        }
    }

    public void TakeHit(float damage)
    {
        aud.PlayOneShot(enemyHit);
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            //Not sure what things need to be done after beating boss. I guess it'll just display a clear screen or move to the game clear screen?

            // spawnEnemy.EnemyDestroyed();
            // DropItem();
            // GameObject.Find("Main Camera").GetComponent<WaveControl>().EnemiesLeft--;
            // Destroy(gameObject);
        }
    }
}