using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public GameObject ProjectilePrefab;
    public float fireRate;

    public float FollowSpeed;

    public float yOffset;

    public float level;

    public Transform target;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Time.timeScale != 0f)
        {
            if(Input.GetKeyDown(KeyCode.Comma) && level > 1)
            {
                level--;
            }

            if(Input.GetKeyDown(KeyCode.Period) && level < 8) {
                level++;
            }

            // Tracks location of target (Set to player game object) and follows it on update
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, 0f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        }
    }


}
