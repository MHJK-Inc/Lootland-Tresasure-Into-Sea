using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{

    public GameObject player;

    public float direction;
    private float distance;

    public float speed = 200f;

    public float life = 250f;

    public float tick = 0f;
    public float maxTick = 0f;
    public float maxLife = 0f;
    public float damage = 0f;

    public float level = 0;

    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;

    private SpriteRenderer sr;

    

    private Vector2 center;

    private float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = one;

        level = GameObject.Find("Laser").GetComponent<Laser>().level;
        DetermineStats();

        player = GameObject.Find("Player");
        center = player.transform.position;

        direction = GameObject.Find("Player").GetComponent<Player>().facing;
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
        if (Time.timeScale != 0f)
        {
            center = player.transform.position;
            transform.position = center;
        }
    }

    void FixedUpdate()
    {
        if (Time.timeScale != 0f)
        {
            //If life of bullet is 0 or less, remove gameObject
            if(life > 0)
            {
                if (life > maxLife - 10) {
                    sr.sprite = one;
                } else if (life > 20) {
                    sr.sprite = two;
                } else if (life > 10) {
                    sr.sprite = three;
                } else {
                    sr.sprite = four;
                }
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
                collider.gameObject.GetComponent<Enemy>().laserTick = 50;
                collider.gameObject.GetComponent<Enemy>().laserPower = 0;
                Debug.Log("Initial Damage");
                collider.gameObject.GetComponent<Enemy>().TakeHit(damage);
                
            } else if (collider.gameObject.GetComponent<ShootingEnemy>() != null)
            {
                collider.gameObject.GetComponent<ShootingEnemy>().laserTick = 50;
                collider.gameObject.GetComponent<ShootingEnemy>().laserPower = 0;
                Debug.Log("Initial Damage");
                collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy")
        {
            if(collider.gameObject.GetComponent<Enemy>() != null)
            {
                if (collider.gameObject.GetComponent<Enemy>().laserTick > 0)
                {
                    collider.gameObject.GetComponent<Enemy>().laserTick--;
                } else
                {
                    if (collider.gameObject.GetComponent<Enemy>().laserPower < 5)
                    {
                        collider.gameObject.GetComponent<Enemy>().laserPower++;
                    }

                    if(collider.gameObject.GetComponent<Enemy>().laserPower < 3)
                    {
                        Debug.Log("Small Damage");
                        collider.gameObject.GetComponent<Enemy>().TakeHit(damage);
                    } else if(collider.gameObject.GetComponent<Enemy>().laserPower < 5)
                    {
                        Debug.Log("Medium Damage");
                        collider.gameObject.GetComponent<Enemy>().TakeHit(damage);
                    } else
                    {
                        Debug.Log("Large Damage");
                        collider.gameObject.GetComponent<Enemy>().TakeHit(damage);
                    }

                    collider.gameObject.GetComponent<Enemy>().laserTick = 50;
                }
                
                
            } else if (collider.gameObject.GetComponent<ShootingEnemy>() != null)
            {
                if (collider.gameObject.GetComponent<ShootingEnemy>().laserTick > 0)
                {
                    collider.gameObject.GetComponent<ShootingEnemy>().laserTick--;
                } else
                {
                    if (collider.gameObject.GetComponent<ShootingEnemy>().laserPower < 5)
                    {
                        collider.gameObject.GetComponent<ShootingEnemy>().laserPower++;
                    }

                    if(collider.gameObject.GetComponent<ShootingEnemy>().laserPower < 3)
                    {
                        Debug.Log("Small Damage");
                        collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
                    } else if(collider.gameObject.GetComponent<ShootingEnemy>().laserPower < 5)
                    {
                        Debug.Log("Medium Damage");
                        collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
                    } else
                    {
                        Debug.Log("Large Damage");
                        collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
                    }

                    collider.gameObject.GetComponent<ShootingEnemy>().laserTick = 50;
                }
            }
        }
    }

    void DetermineStats()
    {
        float dmgMod = 1f + (PlayerPrefs.GetInt("Strength") * 0.1f);
        if (level == 1)
        {
            damage = 1f * dmgMod;
            maxTick = 10f;
            maxLife = 250f;
        } else if (level == 2)
        {
            damage = 1f * dmgMod;
            maxTick = 10f;
            maxLife = 300f;
            transform.localScale = new Vector3(0.25f, 0.25f, 0.4226816f);
        } else if (level == 3)
        {
            damage = 1f * dmgMod;
            maxTick = 6f;
            maxLife = 300f;
            transform.localScale += new Vector3(0.25f, 0.25f, 0.4226816f);
        } else if (level == 4)
        {
            damage = 1f * dmgMod;
            maxTick = 6f;
            maxLife = 350f;
            transform.localScale += new Vector3(0.3f, 0.3f, 0.4226816f);
        } else if (level == 5)
        {
            damage = 2f * dmgMod;
            maxTick = 6f;
            maxLife = 350f;
            transform.localScale += new Vector3(0.3f, 0.3f, 0.4226816f);
        } else if (level == 6)
        {
            damage = 2f * dmgMod;
            maxTick = 6f;
            maxLife = 400f;
            transform.localScale += new Vector3(0.5f, 0.5f, 0.4226816f);
        } else if (level == 7)
        {
            damage = 2f * dmgMod;
            maxTick = 3f;
            maxLife = 400f;
            transform.localScale += new Vector3(0.5f, 0.5f, 0.4226816f);
        } else if (level == 8)
        {
            damage = 3f * dmgMod;
            maxTick = 3f;
            maxLife = 400f;
            transform.localScale += new Vector3(0.5f, 0.5f, 0.4226816f);
        }
    }
}
