using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectileExplosion : MonoBehaviour
{

    private float damage = 3f;
    private float life = 50f;

    // Start is called before the first frame update
    void Start()
    {
        float dmgMod = 1f + (PlayerPrefs.GetInt("Strength") * 0.2f);
        damage = damage * dmgMod;


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
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collider) {
        bool isEnemy = collider.gameObject.CompareTag("Enemy");
        if (isEnemy)
        {
            if(collider.gameObject.GetComponent<Enemy>() != null)
            {
                collider.gameObject.GetComponent<Enemy>().TakeHit(damage);
            }
            
            if (collider.gameObject.GetComponent<ShootingEnemy>() != null)
            {
                collider.gameObject.GetComponent<ShootingEnemy>().TakeHit(damage);
            }

            if (collider.gameObject.GetComponent<SerpentManager>() != null)
            {
                collider.gameObject.GetComponent<SerpentManager>().TakeHit(damage);
            }

            if (collider.gameObject.GetComponent<Boss>() != null)
            {
                collider.gameObject.GetComponent<Boss>().TakeHit(damage);
            }
        }
    }

}
