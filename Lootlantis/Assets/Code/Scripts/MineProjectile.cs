using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectile : MonoBehaviour
{

    public GameObject player;

    public GameObject projectileMini;
    private float distance;

    public float speed = 10f;

    public float life = 250f;

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
                Explode();
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
                Explode();
                Destroy(gameObject);
            } else if (collider.gameObject.GetComponent<ShootingEnemy>() != null)
            {
                collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
                Explode();
                Destroy(gameObject);
            }  else if (collider.gameObject.GetComponent<SerpentManager>() != null)
            {
                collider.gameObject.GetComponent<SerpentManager>().TakeHit(damage);
                Explode();
                Destroy(gameObject);
            }  else if (collider.gameObject.GetComponent<Boss>() != null)
            {
                collider.gameObject.GetComponent<Boss>().TakeHit(damage);
                Explode();
                Destroy(gameObject);
            }
        }
    }

    void DetermineStats()
    {
        float dmgMod = 1f + (PlayerPrefs.GetInt("Strength") * 0.1f);
        if (level == 1)
        {
            damage = 3f * dmgMod;
            maxLife = 250f;
        } else if (level == 2)
        {
            damage = 6f * dmgMod;
            maxLife = 250f;
        } else if (level >= 3)
        {
            damage = 6f * dmgMod;
            maxLife = 250f;
        }
    }

    void Explode()
    {
        if (level != 3) {
            GameObject up = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject down = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject left = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject right = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            
            left.transform.rotation = Quaternion.Euler(Vector3.forward * 90);
            down.transform.rotation = Quaternion.Euler(Vector3.forward * 180);
            right.transform.rotation = Quaternion.Euler(Vector3.forward * 270);
        } else {
            GameObject up = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject down = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject left = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject right = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject upLeft = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject upRight = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject downLeft = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            GameObject downRight = Instantiate(projectileMini, gameObject.transform.position, transform.rotation);
            
            left.transform.rotation = Quaternion.Euler(Vector3.forward * 90);
            down.transform.rotation = Quaternion.Euler(Vector3.forward * 180);
            right.transform.rotation = Quaternion.Euler(Vector3.forward * 270);
            upRight.transform.rotation = Quaternion.Euler(Vector3.forward * 45);
            upLeft.transform.rotation = Quaternion.Euler(Vector3.forward * 315);
            downRight.transform.rotation = Quaternion.Euler(Vector3.forward * 135);
            downLeft.transform.rotation = Quaternion.Euler(Vector3.forward * 225);
        }
        
        
    }
}
