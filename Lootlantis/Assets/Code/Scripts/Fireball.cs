using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Weapon
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
        level = 1;
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
        if(GameObject.Find("FireballProjectile") == null) {
            if(fireRate > 0)
            {
                fireRate = fireRate - (1f + (PlayerPrefs.GetInt("AttackSpeed") * 0.1f));
            } else 
            {
                aud.PlayOneShot(fireAud);
                Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                if (level == 8) {
                    fireRate = 10f;
                } else if (level < 8 && level > 5) {
                    fireRate = 20f;
                } else if (level < 6 && level > 3) {
                    fireRate = 30f;
                } else if (level < 4 && level > 1) {
                    fireRate = 40f;
                } else {
                    fireRate = 50f;
                }
            }
        }
    }

}
