using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectileMini : MonoBehaviour
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
        level = GameObject.Find("Mine").GetComponent<Mine>().level;
        DetermineStats();

        player = GameObject.Find("Player");
        center = player.transform.position;
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

    void DetermineStats()
    {
        float dmgMod = 1f + (PlayerPrefs.GetInt("Strength") * 0.1f);
        if (level == 1)
        {
            damage = 2f * dmgMod;
            maxTick = 10f;
            maxLife = 250f;
        } else if (level == 2)
        {
            damage = 4f * dmgMod;
            maxTick = 10f;
            maxLife = 300f;
            transform.localScale = new Vector3(0.25f, 0.25f, 0.4226816f);
        } else if (level == 3)
        {
            damage = 4f * dmgMod;
            maxTick = 6f;
            maxLife = 300f;
            transform.localScale += new Vector3(0.25f, 0.25f, 0.4226816f);
        }
    }
}