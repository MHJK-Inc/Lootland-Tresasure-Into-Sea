using System.Collections;
using System.Collections.Generic;
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
            collider.gameObject.GetComponent<Enemy>().TakeHit(1);
            Destroy(gameObject);
        }
    }


}
