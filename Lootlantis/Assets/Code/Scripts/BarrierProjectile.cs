using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierProjectile : MonoBehaviour
{

    public GameObject player;
    private float distance;

    public float speed = 200f;

    public float life = 250f;

    public float tick = 0f;
    public float maxTick = 0f;
    public float maxLife = 0f;
    public float damage = 0f;

    public float level = 0;

    

    private Vector2 center;

    private float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Barrier").GetComponent<Barrier>().level;
        DetermineStats();

        player = GameObject.Find("Player");
        center = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            center = player.transform.position;
            transform.position = center;
            
            rotZ += -Time.deltaTime * speed;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }

    void FixedUpdate()
    {
        if (Time.timeScale != 0f)
        {
            if (tick == 0) {
                tick = 10;
            } else {
                tick--;
            }


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

    private void OnTriggerEnter2D(Collider2D collider) {
        if(tick == 0) {
            if (collider.gameObject.tag == "Enemy")
            {
                if(collider.gameObject.GetComponent<Enemy>() != null)
                {
                    collider.gameObject.GetComponent<Enemy>().TakeHit(damage);
                } else if (collider.gameObject.GetComponent<ShootingEnemy>() != null)
                {
                    collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if(tick == 0) {
            if (collider.gameObject.tag == "Enemy")
            {
                if(collider.gameObject.GetComponent<Enemy>() != null)
                {
                    collider.gameObject.GetComponent<Enemy>().TakeHit(damage);
                } else if (collider.gameObject.GetComponent<ShootingEnemy>() != null)
                {
                    collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
                }
            }
        }
    }

    void DetermineStats()
    {
        if (level == 1)
        {
            damage = 1f;
            maxTick = 10f;
            maxLife = 250f;
        } else if (level == 2)
        {
            damage = 1f;
            maxTick = 10f;
            maxLife = 300f;
            transform.localScale = new Vector3(0.25f, 0.25f, 0.4226816f);
        } else if (level == 3)
        {
            damage = 1f;
            maxTick = 6f;
            maxLife = 300f;
            transform.localScale += new Vector3(0.25f, 0.25f, 0.4226816f);
        } else if (level == 4)
        {
            damage = 1f;
            maxTick = 6f;
            maxLife = 350f;
            transform.localScale += new Vector3(0.3f, 0.3f, 0.4226816f);
        } else if (level == 5)
        {
            damage = 2f;
            maxTick = 6f;
            maxLife = 350f;
            transform.localScale += new Vector3(0.3f, 0.3f, 0.4226816f);
        } else if (level == 6)
        {
            damage = 2f;
            maxTick = 6f;
            maxLife = 400f;
            transform.localScale += new Vector3(0.5f, 0.5f, 0.4226816f);
        } else if (level == 7)
        {
            damage = 2f;
            maxTick = 3f;
            maxLife = 400f;
            transform.localScale += new Vector3(0.5f, 0.5f, 0.4226816f);
        } else if (level == 8)
        {
            damage = 3f;
            maxTick = 3f;
            maxLife = 400f;
            transform.localScale += new Vector3(0.5f, 0.5f, 0.4226816f);
        }
    }
}
