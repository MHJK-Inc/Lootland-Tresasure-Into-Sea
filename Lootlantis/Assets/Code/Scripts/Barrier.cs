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
        if (Time.timeScale != 0f)
        {
            Fire();
        }
    }

    protected void Fire()
    {
        if(GameObject.Find("BarrierProjectile") == null) {
            if(fireRate > 0)
            {
                fireRate = fireRate - (1f + (PlayerPrefs.GetInt("AttackSpeed") * 0.1f));
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
