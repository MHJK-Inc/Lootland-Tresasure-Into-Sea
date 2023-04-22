using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed = 1f;
    private float distance;
    public GameObject player;

    public GameObject coin;
    public GameObject bubble;
    public GameObject projectile;
    public GameObject projectileParent;
    public float shootingRange;
    public float fireRate = 2f;
    private float nextFireTime;


    public float distanceFromPlayer = 25f;
    public float minDistance = 0.2f;
    public float maxDistance = 0.5f;

    private float minD;
    private float maxD;

    //Added By Kris
    private SpawnShootingEnemy spawnShootingEnemy;

    public HealthBarBehavior healthBar;

    public float hitPoints;
    public float maxHitPoints = 5;
    public float laserTick;
    public float laserPower;

    public AudioSource aud;
    public AudioClip audPlayerHit;
    public AudioClip enemyHit;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemy";

        //On creation finds the "Player" gameobject
        player = GameObject.Find("Player");

        minD = distanceFromPlayer * minDistance;
        maxD = distanceFromPlayer * maxDistance;
        //Added by Kris
        spawnShootingEnemy = FindObjectOfType<SpawnShootingEnemy>();
        SetHealth();
        hitPoints = maxHitPoints;
        healthBar.SetHealth(hitPoints, maxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            if (distance >= distanceFromPlayer)
            {
                //Debug.Log("distance:" + distance);
                //Debug.Log("distanceFromPlayer:" + distanceFromPlayer);
                // Move the enemy to a new location near the player
                MoveCloserToPlayer();
            }
            else
            {
                // Continue with the normal movement
                Move();
            }

            //Using the player as reference, gets the distance and direction of the player
            distance = Vector2.Distance(transform.position, player.GetComponent<Player>().transform.position);

            if (distance > shootingRange)
            {
                Vector2 direction = player.transform.position - player.GetComponent<Player>().transform.position;

                //Moves enemy towards the player's position on Update
                transform.position = Vector2.MoveTowards(this.transform.position, player.GetComponent<Player>().transform.position, speed * Time.deltaTime);

            }
            else if (distance <= shootingRange && nextFireTime < Time.time)
            {
                Instantiate(projectile, projectileParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
        }

    }

    public void SetHealth()
    {

        if (PlayerPrefs.GetInt("Wave") == 1)
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnShootingEnemy.totalWeapons * .85f;
        }
        else if (PlayerPrefs.GetInt("Wave") == 2)
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnShootingEnemy.totalWeapons * .85f;
        }
        else if (PlayerPrefs.GetInt("Wave") == 3)
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnShootingEnemy.totalWeapons * .85f;
        }
        else if (PlayerPrefs.GetInt("Wave") == 4)
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnShootingEnemy.totalWeapons * .85f;
        }
        else
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnShootingEnemy.totalWeapons * .85f;
        }
    }

    void Move()
    {
        //Using the player as reference, gets the distance and direction of the player
        distance = Vector2.Distance(transform.position, player.GetComponent<Player>().transform.position);
        Vector2 direction = player.transform.position - player.GetComponent<Player>().transform.position;

        //Moves enemy towards the player's position on Update
        transform.position = Vector2.MoveTowards(this.transform.position, player.GetComponent<Player>().transform.position, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    public void TakeHit(float damage)
    {
        aud.PlayOneShot(enemyHit);
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            spawnShootingEnemy.EnemyDestroyed();
            DropItem();
            GameObject.Find("Main Camera").GetComponent<WaveControl>().EnemiesLeft--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            aud.PlayOneShot(audPlayerHit);
            collision.gameObject.GetComponent<Player>().TakeDamage(5);
        }

    }

    public void DropItem()
    {
        float dropChance = 0.5f; 
        float value = Random.value;
        if (Random.value <= dropChance)
        {
            // Spawn the item at the enemy's position
            float whichDrop = 0.5f;
            value = Random.value;
            if(value <= whichDrop)
            {
              GameObject item = Instantiate(bubble, transform.position, Quaternion.identity);  
            } else
            {
                GameObject item = Instantiate(coin, transform.position, Quaternion.identity);
            }
            
        }
    }

    void MoveCloserToPlayer()
    {
        float distanceToMove = Random.Range(minD, maxD);
        float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        Vector3 newPosition = new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0) * distanceToMove;
        newPosition += player.transform.position;

        // Ensure the new position is within the game boundaries (if necessary)
        // newPosition = ClampPosition(newPosition);

        transform.position = newPosition;
    }
}
