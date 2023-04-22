using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject target;
    public GameObject player;
    public float speed;
    public float life;
    Rigidbody2D bulletRB;

    public Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        life = 200;
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        
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


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerScript = collider.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                StartCoroutine(playerScript.FlashAfterDamage());
                playerScript.TakeDamage(5);
            }
            Destroy(gameObject);
            
        }
        
        
    }
}
