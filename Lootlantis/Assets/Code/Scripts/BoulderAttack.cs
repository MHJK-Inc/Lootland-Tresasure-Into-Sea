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
    public AudioSource aud;
    public AudioClip audPlayerHit;
    public AudioClip boulderBreak;


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
        AudioSource bo = GameObject.Find("Boss Head").GetComponent<AudioSource>();
        bo.PlayOneShot(boulderBreak);
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
            aud.PlayOneShot(audPlayerHit);
            collider.gameObject.GetComponent<Player>().TakeDamage(5);
            aud.PlayOneShot(boulderBreak);
            BoulderDestroy();
        }
    }
}
