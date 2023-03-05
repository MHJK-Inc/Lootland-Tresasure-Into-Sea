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

    public HealthBarBehavior healthBar;
    public Rigidbody2D rb;
    private Vector2 movement;
    public float hitPoints;
    public float maxHitPoints = 5;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemy";

        //On creation finds the "Player" gameobject
        player =  GameObject.Find("Player");

        //Added by Kris
        spawnEnemy = FindObjectOfType<SpawnEnemy>();
        hitPoints = maxHitPoints;
        healthBar.SetHealth(hitPoints, maxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        //Using the player as reference, gets the distance and direction of the player
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (direction.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            Debug.Log("Flipping sprite to face left");
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            Debug.Log("Flipping sprite to face right");
        }

        direction.Normalize();
        movement = direction;
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
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            spawnEnemy.EnemyDestroyed();
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
