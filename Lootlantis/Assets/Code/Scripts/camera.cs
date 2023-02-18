using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Speed that it follows
    public float FollowSpeed = 2f;

    public float yOffset = 1f;

    // Target that it follows
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Tracks location of target (Set to player game object) and follows it on update
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
