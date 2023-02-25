using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public GameObject enemy;
    private float distance;

    public float speed = 4.5f;

    public float life = 100f;

    public float rotationSpeed = 20;

    private Quaternion lookRotation;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
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

    void FixedUpdate()
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

    private GameObject FindClosestEnemy()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] shootingEnemies = GameObject.FindGameObjectsWithTag("Shooting Enemy");
        List<GameObject> allEnemies = new List<GameObject>(gos);
        allEnemies.AddRange(shootingEnemies);

        if (allEnemies.Count == 0)
        {
            return null;
        }

        GameObject closest = allEnemies[0];
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in allEnemies)
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        ShootingEnemy shootingEnemy = collider.GetComponent<ShootingEnemy>();

        if (enemy != null)
        {
            enemy.TakeHit(1);
        }

        if (shootingEnemy != null)
        {
            shootingEnemy.TakeHit(1);
        }
    }


}
