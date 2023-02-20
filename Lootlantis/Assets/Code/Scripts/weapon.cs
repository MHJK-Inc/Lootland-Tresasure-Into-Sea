using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject ProjectilePrefab;
    public float fireRate = 50f;
    //public BoxCollider2D projectileCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
