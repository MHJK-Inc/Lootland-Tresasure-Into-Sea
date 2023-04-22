using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{

    public AudioSource aud;
    public AudioClip fireAud;

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
        if(GameObject.Find("LaserProjectile") == null) {
            if(fireRate > 0)
            {
                fireRate = fireRate - (1f + (PlayerPrefs.GetInt("AttackSpeed") * 0.1f));
            } else 
            {
                aud.PlayOneShot(fireAud);
                Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                if (level >= 2) {
                    fireRate = 300f;
                } else {
                    fireRate = 400f;
                }
            }
        }
    }
}
