using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public float fireRate = 50f;

    public float FollowSpeed = 10f;

    public float yOffset = 0f;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Tracks location of target (Set to player game object) and follows it on update
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, 0f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }

    void FixedUpdate()
    {
        Fire();

    }

    void Fire()
    {
        if(fireRate > 0)
        {
            fireRate--;
        } else 
        {
            Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            fireRate = 50f;
        }
    }
}
