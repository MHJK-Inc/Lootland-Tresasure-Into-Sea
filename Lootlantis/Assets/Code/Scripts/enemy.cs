using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpawnEnemy spawnEnemy;

    public GameObject player;
    public float speed = 1f;
    public HealthBarBehavior healthBar;
    public float hitPoints;
    public float maxHitPoints = 5;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        //On creation finds the "Player" gameobject
        player =  GameObject.Find("Player");
        spawnEnemy = FindObjectOfType<SpawnEnemy>();
        hitPoints = maxHitPoints;
        healthBar.SetHealth(hitPoints, maxHitPoints);

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

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //Using the player as reference, gets the distance and direction of the player
        distance = Vector2.Distance(transform.position, player.GetComponent<Player>().transform.position);
        Vector2 direction = player.transform.position - player.GetComponent<Player>().transform.position;

        //Moves enemy towards the player's position on Update
        transform.position = Vector2.MoveTowards(this.transform.position, player.GetComponent<Player>().transform.position, speed * Time.deltaTime);
    }
}
