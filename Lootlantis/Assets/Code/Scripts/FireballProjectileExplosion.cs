using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectileExplosion : MonoBehaviour
{

    private float damage = 4f;
    private float life = 10f;

    // Start is called before the first frame update
    void Start()
    {


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
        }
    }

}
