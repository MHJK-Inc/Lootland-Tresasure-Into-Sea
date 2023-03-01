using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
     public GameObject ProjectilePrefab;
    public float fireRate = 400f;

    public float FollowSpeed = 10f;

    public float yOffset = 0f;

    public float level = 1f;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 400f;
        FollowSpeed = 10f;
        yOffset = 0f;
        level = 1f;
    }

    // Update is called once per frame
    void Update()
    {
         // Tracks location of target (Set to player game object) and follows it on update
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, 0f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Comma))
        {
            level--;
        }

        if(Input.GetKeyDown(KeyCode.Period)) {
            level++;
        }

    }

    void FixedUpdate()
    {
        Fire();

    }

    void Fire()
    {
        if(GameObject.Find("BarrierProjectile") == null) {
            if(fireRate > 0)
            {
                fireRate--;
            } else 
            {
                Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                if (level == 8) {
                    fireRate = 300f;
                } else {
                    fireRate = 400f;
                }
            }
        }
    }
}
