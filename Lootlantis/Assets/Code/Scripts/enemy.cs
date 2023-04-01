using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 1f;
    private float distance;

    //Added By Kris
    private SpawnEnemy spawnEnemy;

    public GameObject coin;
    public GameObject bubble;
    public HealthBarBehavior healthBar;

    public float distanceFromPlayer = 10f;
    public float minDistance = 0.2f;
    public float maxDistance = 0.5f;

    private float minD;
    private float maxD;

    public Rigidbody2D rb;
    private Vector2 movement;

    public float hitPoints;
    public float maxHitPoints = 5;

    public AudioSource aud;
    public AudioClip audPlayerHit;
    public AudioClip enemyHit;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.tag = "Enemy";

        //On creation finds the "Player" gameobject
        player =  GameObject.Find("Player");

        minD = distanceFromPlayer * minDistance;
        maxD = distanceFromPlayer * maxDistance;

        //Added by Kris
        spawnEnemy = FindObjectOfType<SpawnEnemy>();
        SetHealth();
        hitPoints = maxHitPoints;
        healthBar.SetHealth(hitPoints, maxHitPoints);
    }

    public void SetHealth()
    {

        if (PlayerPrefs.GetInt("Wave") == 1)
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnEnemy.totalWeapons * .85f;
        }
        else if (PlayerPrefs.GetInt("Wave") == 2)
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnEnemy.totalWeapons * .85f;
        }
        else if (PlayerPrefs.GetInt("Wave") == 3)
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnEnemy.totalWeapons * .85f;
        }
        else if (PlayerPrefs.GetInt("Wave") == 4)
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnEnemy.totalWeapons * .85f;
        }
        else
        {
            maxHitPoints = maxHitPoints * PlayerPrefs.GetInt("Wave") + spawnEnemy.totalWeapons * .85f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            if(player == null)
            {
                player = GameObject.Find("Player");
            }
            // Check the distance between the enemy and the player
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance >= distanceFromPlayer)
            {
                Debug.Log("distance:" + distance);
                Debug.Log("distanceFromPlayer:" + distanceFromPlayer);
                // Move the enemy to a new location near the player
                MoveCloserToPlayer();
            }
            else
            {
                // Continue with the normal movement
                Move();
            }
        }
    }

    void Move()
    {
        if (player != null)
        {
            //Using the player as reference, gets the distance and direction of the player
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

            if (direction.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    public void TakeHit(float damage)
    {
        aud.PlayOneShot(enemyHit);
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            spawnEnemy.EnemyDestroyed();
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
        if (Random.value <= dropChance)
        {
            // Spawn the item at the enemy's position
            float whichDrop = 0.5f;
            if(Random.value <= whichDrop)
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
