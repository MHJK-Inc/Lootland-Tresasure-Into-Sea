using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearGun : MonoBehaviour
{

    public GameObject ProjectilePrefab;
    public float fireRate = 50f;

    public float FollowSpeed = 10f;

    public float yOffset = 0f;

    public float level = 1f;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 50f;
        FollowSpeed = 10f;
        yOffset = 0f;
        level = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Comma))
        {
            level--;
        }

        if(Input.GetKeyDown(KeyCode.Period)) {
            level++;
        }

        Debug.Log("Level: " + level);

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
        if(GameObject.Find("SpearGunProjectile") == null) {
            if(fireRate > 0)
            {
                fireRate--;
            } else 
            {
                Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                if (level < 9 && level > 6) {
                    fireRate = 30f;
                } else if (level < 7 && level > 2) {
                    fireRate = 40f;
                } else {
                    fireRate = 50f;
                }
                
            }
        }
    }
}
