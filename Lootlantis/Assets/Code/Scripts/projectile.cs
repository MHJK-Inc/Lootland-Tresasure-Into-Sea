using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float Speed = 4.5f;
    public float life = 100f;
    public float direction = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Finds player's direction they're facing (See player script)
        direction = GameObject.Find("Player").GetComponent<player>().facing;
    }

    // Update is called once per frame
    void Update()
    {

        //Direction of Bullet (numbers refer to player script)
        if(direction == 0)
        {
            transform.position += transform.up * Time.deltaTime * Speed;
        } else if(direction == 1)
        {
            transform.position += transform.up * Time.deltaTime * Speed;
            transform.position += transform.right * Time.deltaTime * Speed;
        } else if(direction == 2)
        {
            transform.position += transform.right * Time.deltaTime * Speed;
        } else if(direction == 3)
        {
            transform.position += transform.right * Time.deltaTime * Speed;
            transform.position += -transform.up * Time.deltaTime * Speed;   
        } else if(direction == 4)
        {
            transform.position += -transform.up * Time.deltaTime * Speed;
        } else if(direction == 5)
        {
            transform.position += -transform.right * Time.deltaTime * Speed;
            transform.position += -transform.up * Time.deltaTime * Speed;
        } else if(direction == 6)
        {
            transform.position += -transform.right * Time.deltaTime * Speed;
        } else
        {
            transform.position += -transform.right * Time.deltaTime * Speed;
            transform.position += transform.up * Time.deltaTime * Speed;
        }
    }

    void FixedUpdate()
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

    private void OnTriggerEnter2d(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.name);
        //Destroy(gameObject);
    }
}
