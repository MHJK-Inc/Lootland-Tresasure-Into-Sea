using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public GameObject enemy;
    private float distance;

    public float speed = 4.5f;

    public float life = 100f;

    public float rotationSpeed = 20f;

    private Quaternion lookRotation;
    private Vector3 direction;

    private float level = 0f;

    private float damage = 0f;

    // Start is called before the first frame update
    void Start()
    {
        life = 200f;
        rotationSpeed = 30f;
        level = GameObject.Find("Fireball").GetComponent<Fireball>().level;
        DetermineStats();
        enemy = FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            if(enemy)
            {
                Move();
            } else
            {
                enemy = GameObject.Find("DefaultEnemy");
                Move();
            }

            direction = (enemy.transform.position - transform.position).normalized;

            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90;

            lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }

        


        

    }

    void FixedUpdate()
    {
        if (Time.timeScale != 0f)
        {
            //If life of bullet is 0 or less, remove gameObject
            if(life > 0)
            {
                life--;
            } else 
            {
                Destroy(gameObject);
            }
        }

    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length == 0)
        {
            enemy = GameObject.Find("DefaultEnemy");
        }
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = GameObject.Find("Player").GetComponent<Player>().transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        return closest;
    }

    void Move()
    {
        //Using the player as reference, gets the distance and direction of the player
        distance = Vector2.Distance(transform.position, enemy.transform.position);
        //Vector2 direction = enemy.transform.position - enemy.GetComponent<Enemy>().transform.position;

        //Moves enemy towards the player's position on Update
        transform.position = Vector2.MoveTowards(this.transform.position, enemy.transform.position, speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy")
        {
            if(collider.gameObject.GetComponent<Enemy>() != null)
            {
                collider.gameObject.GetComponent<Enemy>().TakeHit(damage);
                Destroy(gameObject);
            } else if (collider.gameObject.GetComponent<ShootingEnemy>() != null)
            {
                collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
                Destroy(gameObject);
            }
        }
    }

    void DetermineStats()
    {
        if (level == 1)
        {
            damage = 2f;
            speed = 4.5f;
        } else if (level == 2)
        {
            damage = 2f;
            speed = 4.5f;
        } else if (level == 3)
        {
            damage = 4f;
            speed = 4.5f;
        } else if (level == 4)
        {
            damage = 4f;
            speed = 4.5f;
        } else if (level == 5)
        {
            damage = 4f;
            speed = 9f;
        } else if (level == 6)
        {
            damage = 4f;
            speed = 9f;
        } else if (level == 7)
        {
            damage = 6f;
            speed = 9f;
        } else if (level == 8)
        {
            damage = 6f;
            speed = 15f;
        }
    }

}
