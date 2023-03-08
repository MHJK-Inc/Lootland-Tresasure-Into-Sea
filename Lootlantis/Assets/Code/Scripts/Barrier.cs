using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : Weapon
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        fireRate = 0f;
        FollowSpeed = 10f;
        yOffset = 0f;
        level = 1f;
    }

    protected void FixedUpdate()
    {
        Fire();

    }

    protected void Fire()
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
