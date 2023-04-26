using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonGunProjectile : MonoBehaviour
{

    public float speed = 4.5f;
    public float life = 100f;
    public float direction = 0f;
    public float level = 0f;
    public float damage = 0f;
    public float pierce = 0f;

    // Start is called before the first frame update
    void Start()
    {

        life = 200f;


        level = PlayerPrefs.GetInt("HarpoonGun");
        DetermineStats();

        // Finds player's direction they're facing (See player script)

        //Direction of Bullet (numbers refer to player script)
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            transform.position += transform.up * Time.deltaTime * speed;
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

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy")
        {
            if(collider.gameObject.GetComponent<Enemy>() != null)
            {
                collider.gameObject.GetComponent<Enemy>().TakeHit(damage);
                if(pierce > 0)
                {
                    pierce--;
                } else
                {
                    Destroy(gameObject);
                }
            } else if (collider.gameObject.GetComponent<ShootingEnemy>() != null)
            {
                collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
                if(pierce > 0)
                {
                    pierce--;
                } else
                {
                    Destroy(gameObject);
                }
            }  else if (collider.gameObject.GetComponent<SerpentManager>() != null)
            {
                collider.gameObject.GetComponent<SerpentManager>().TakeHit(damage);
                if(pierce > 0)
                {
                    pierce--;
                } else
                {
                    Destroy(gameObject);
                }
            } else if (collider.gameObject.GetComponent<Boss>() != null)
            {
                collider.gameObject.GetComponent<Boss>().TakeHit(damage);
                if(pierce > 0)
                {
                    pierce--;
                } else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void DetermineStats()
    {
        float dmgMod = 1f + (PlayerPrefs.GetInt("Strength") * 0.2f);
        if (level == 1)
        {
            damage = 4f * dmgMod;
            speed = 12f;
            pierce = 3f;
        } else if (level == 2)
        {
            damage = 4f * dmgMod;
            speed = 12f;
            pierce = 5f;
        } else if (level >= 3)
        {
            damage = 6f * dmgMod;
            speed = 15f;
            pierce = 7f;
        }
    }
}
