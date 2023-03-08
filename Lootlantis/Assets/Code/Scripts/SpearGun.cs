using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearGun : Weapon
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
