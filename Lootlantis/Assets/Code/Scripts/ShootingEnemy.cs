using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed = 1f;
    private float distance;
    public GameObject player;

    public GameObject projectile;
    public GameObject projectileParent;
    public float shootingRange;
    public float fireRate = 2f;
    private float nextFireTime;

    //Added By Kris
    private SpawnShootingEnemy spawnShootingEnemy;

    public HealthBarBehavior healthBar;

    public float hitPoints;
    public float maxHitPoints = 5;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemy";

        //On creation finds the "Player" gameobject
        player = GameObject.Find("Player");

        //Added by Kris
        spawnShootingEnemy = FindObjectOfType<SpawnShootingEnemy>();
        hitPoints = maxHitPoints;
        healthBar.SetHealth(hitPoints, maxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        
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
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            spawnShootingEnemy.EnemyDestroyed();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(5);
        }

    }
}
