using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPProjectile : MonoBehaviour
{

    public GameObject player;
    private float distance;

    public float speed = 10f;

    public float life = 250f;

    public float tick = 10f;
    public float maxTick = 0f;
    public float maxLife = 0f;
    public float damage = 0f;

    public float level = 0;

    

    private Vector2 center;

    private float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("EMP");
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
            
            //rotZ += -Time.deltaTime * speed;

            //transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }

    void FixedUpdate()
    {
        if (Time.timeScale != 0f)
        {
            if (tick == 0) {
                tick = maxTick;
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
                } else if (collider.gameObject.GetComponent<SerpentManager>() != null)
                {
                    collider.gameObject.GetComponent<SerpentManager>().TakeHit(damage);
                } else if (collider.gameObject.GetComponent<Boss>() != null)
                {
                    collider.gameObject.GetComponent<Boss>().TakeHit(damage);
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
                } else if (collider.gameObject.GetComponent<SerpentManager>() != null)
                {
                    collider.gameObject.GetComponent<SerpentManager>().TakeHit(damage);
                }  else if (collider.gameObject.GetComponent<Boss>() != null)
                {
                    collider.gameObject.GetComponent<Boss>().TakeHit(damage);
                }
            }
        }
    }

    void DetermineStats()
    {
        float dmgMod = 1f + (PlayerPrefs.GetInt("Strength") * 0.2f);
        if (level == 1)
        {
            damage = 1f * dmgMod;
            maxTick = 20f;
            maxLife = 300f;
        } else if (level == 2)
        {
            damage = 1f * dmgMod;
            maxTick = 20f;
            maxLife = 300f;
            transform.localScale = new Vector3(0.75f, 0.75f, 0.4226816f);
        } else if (level >= 3)
        {
            damage = 1f * dmgMod;
            maxTick = 20f;
            maxLife = 300f;
            transform.localScale = new Vector3(1f, 1f, 0.4226816f);
        }
    }
}
