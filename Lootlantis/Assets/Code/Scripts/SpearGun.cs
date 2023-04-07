using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpearGun : Weapon
{

    public AudioSource aud;
    public AudioClip fireAud;

    bool canFire = true;
    float cooldownTime = 1.5f;




    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        fireRate = 120f; //2 seconds
        FollowSpeed = 10f;
        yOffset = 0f;
        level = 1f;

        canFire = true;
        cooldownTime = 1.5f;


        
    }

    protected void Update()
    {
        if (Input.GetKeyDown("space") && canFire){
        Fire();
        canFire = false;
        StartCoroutine(ResetCooldown());
        }
    }

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canFire = true;
    }
    protected void FixedUpdate()
    {
        

    }

    protected void Fire()
    {
        if(GameObject.Find("SpearGunProjectile") == null) {

                aud.PlayOneShot(fireAud);
                Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                if (level < 9 && level > 6) {
                    fireRate = 30f;
                } else if (level < 7 && level > 2) {
                    fireRate = 60f;
                } else {
                    fireRate = 90f;
                }
                
            
        }
    }
}
