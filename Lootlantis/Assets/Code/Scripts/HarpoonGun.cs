using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HarpoonGun : Weapon
{

    public AudioSource aud;
    public AudioClip fireAud;
    bool canFire = true;
    float cooldownTime = 3f;

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
            //Fire();
        }

    }

    protected override void Update()
    {
        if (Time.timeScale != 0f)
        {

            // Tracks location of target (Set to player game object) and follows it on update
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, 0f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
            if (Input.GetKeyDown("space") && canFire){
                //Debug.Log("Fire Pressed");
                Fire();
                canFire = false;
                StartCoroutine(ResetCooldown());
            }
        }
    }

    IEnumerator ResetCooldown()
    {
        if(PlayerPrefs.GetInt("HarpoonGun") == 3) {
            yield return new WaitForSeconds(1.5f);
        } else {
            yield return new WaitForSeconds(3f);
        }
        yield return new WaitForSeconds(cooldownTime);
        canFire = true;
    }

    protected void Fire()
    {
        aud.PlayOneShot(fireAud);
        //Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
        fireRate = 70f;
        float direction = GameObject.Find("Player").GetComponent<Player>().facing;
        if (direction == 0)
        {
            GameObject projectile = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            projectile.transform.rotation = Quaternion.Euler(Vector3.forward * 0);
        } else if(direction == 1)
        {
            GameObject projectile = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            projectile.transform.rotation = Quaternion.Euler(Vector3.forward * -45);
        } else if(direction == 2)
        {
            GameObject projectile = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            projectile.transform.rotation = Quaternion.Euler(Vector3.forward * -90);
        } else if(direction == 3)
        {
            GameObject projectile = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            projectile.transform.rotation = Quaternion.Euler(Vector3.forward * -135);
        } else if(direction == 4)
        {
            GameObject projectile = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            projectile.transform.rotation = Quaternion.Euler(Vector3.forward * -180);
        } else if(direction == 5)
        {
            GameObject projectile = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            projectile.transform.rotation = Quaternion.Euler(Vector3.forward * -225);
        } else if(direction == 6)
        {
            GameObject projectile = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            projectile.transform.rotation = Quaternion.Euler(Vector3.forward * -270);
        } else
        {
            GameObject projectile = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            projectile.transform.rotation = Quaternion.Euler(Vector3.forward * -315);
        }
    }
}
