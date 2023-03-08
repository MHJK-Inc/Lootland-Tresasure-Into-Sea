using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearGunProjectile : MonoBehaviour
{

    public float speed = 4.5f;
    public float life = 100f;
    public float direction = 0f;
    public float level = 0f;
    public float damage = 0f;

    // Start is called before the first frame update
    void Start()
    {

        life = 200f;


        level = GameObject.Find("SpearGun").GetComponent<SpearGun>().level;
        DetermineStats();

        // Finds player's direction they're facing (See player script)
        direction = GameObject.Find("Player").GetComponent<Player>().facing;

        //Direction of Bullet (numbers refer to player script)
        if (direction == 0)
        {

        } else if(direction == 1)
        {
            transform.Rotate(0f, 0f, 315f);
        } else if(direction == 2)
        {
            transform.Rotate(0f, 0f, 270f);
        } else if(direction == 3)
        {
            transform.Rotate(0f, 0f, 225f); 
        } else if(direction == 4)
        {
            transform.Rotate(0f, 0f, 180f);
        } else if(direction == 5)
        {
            transform.Rotate(0f, 0f, 135f);
        } else if(direction == 6)
        {
            transform.Rotate(0f, 0f, 90f);
        } else
        {
            transform.Rotate(0f, 0f, 45f);
        }
    }

    // Update is called once per frame
    void Update()
    {
            transform.position += transform.up * Time.deltaTime * speed;
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
            damage = 3f;
            speed = 4.5f;
        } else if (level == 2)
        {
            damage = 5f;
            speed = 4.5f;
        } else if (level == 3)
        {
            damage = 5f;
            speed = 4.5f;
        } else if (level == 4)
        {
            damage = 5f;
            speed = 6f;
        } else if (level == 5)
        {
            damage = 8f;
            speed = 6f;
        } else if (level == 6)
        {
            damage = 8f;
            speed = 6f;
            transform.localScale = new Vector3(0.25f, 0.25f, 0.4226816f);
        } else if (level == 7)
        {
            damage = 8f;
            speed = 6f;
            transform.localScale = new Vector3(0.25f,0.25f, 0.4226816f);
        } else if (level == 8)
        {
            damage = 10f;
            speed = 7.5f;
            transform.localScale = new Vector3(0.25f, 0.25f, 0.4226816f);
        }
    }
}
