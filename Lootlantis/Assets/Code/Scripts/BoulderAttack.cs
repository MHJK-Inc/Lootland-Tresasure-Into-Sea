using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderAttack : MonoBehaviour
{
    GameObject target;
    public float speed;
    public float life;
    Rigidbody2D bulletRB;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        life = 200;
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        bulletRB.velocity = Vector2.down * speed;
        animator = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        if (Time.timeScale != 0f)
        {
            //If life of bullet is 0 or less, remove gameObject
            if (life > 0)
            {
                life--;
            }
            else
            {
                BoulderDestroy();
            }
        }

    }

    public void BoulderDestroy() {
        animator.SetTrigger("BoulderDestroy");
    }

    public void RemoveBoulder()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Player>().TakeDamage(5);
            BoulderDestroy();
        }
    }
}
