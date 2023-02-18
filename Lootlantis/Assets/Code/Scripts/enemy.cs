using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 1f;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        //On creation finds the "Player" gameobject
        player =  GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //Using the player as reference, gets the distance and direction of the player
        distance = Vector2.Distance(transform.position, player.GetComponent<player>().transform.position);
        Vector2 direction = player.transform.position - player.GetComponent<player>().transform.position;

        //Moves enemy towards the player's position on Update
        transform.position = Vector2.MoveTowards(this.transform.position, player.GetComponent<player>().transform.position, speed * Time.deltaTime);
    }
}
