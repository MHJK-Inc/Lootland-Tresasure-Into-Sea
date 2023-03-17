using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityProjectile : MonoBehaviour
{
    public GameObject player;
    private float distance;

    public float speed = 4.5f;

    public float life = 100f;

    private float RotateSpeed = 5f;
    private float Radius = 3f;

    private Vector2 center;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        center = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            center = player.transform.position;
            angle += RotateSpeed * Time.deltaTime;
            
            var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
            transform.position = center + offset;
        }

    }

    void FixedUpdate()
    {
        //If life of bullet is 0 or less, remove gameObject
        if (Time.timeScale != 0f)
        {
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
        if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<Enemy>().TakeHit(1);
            Destroy(gameObject);
        }
    }

}
