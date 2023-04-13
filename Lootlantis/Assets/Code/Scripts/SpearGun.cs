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

        fireRate = 0f;
        FollowSpeed = 10f;
        yOffset = 0f;
        level = 1f;
    }

    protected override void Update()
    {
        if (Time.timeScale != 0f)
        {
            if(Input.GetKeyDown(KeyCode.Comma) && level > 1)
            {
                level--;
            }

            if(Input.GetKeyDown(KeyCode.Period) && level < 3) {
                level++;
            }

            // Tracks location of target (Set to player game object) and follows it on update
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, 0f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
            if (Input.GetKeyDown("space") && canFire){
                Debug.Log("Fire Pressed");
                Fire();
                canFire = false;
                StartCoroutine(ResetCooldown());
            }
        }
    }

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canFire = true;
    }

    protected void FixedUpdate()
    {
        if (Time.timeScale != 0f)
        {
            //Fire();
        }

    }

    protected void Fire()
    {
        aud.PlayOneShot(fireAud);
        float direction = GameObject.Find("Player").GetComponent<Player>().facing;
        if (direction == 0)
        {
            GameObject first = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            GameObject second;
            GameObject third;
            if (PlayerPrefs.GetInt("SpearGun") >= 2)
            {
                second = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                third = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                
                second.transform.rotation = Quaternion.Euler(Vector3.forward * 20);
                third.transform.rotation = Quaternion.Euler(Vector3.forward * -20);
            }
            first.transform.rotation = Quaternion.Euler(Vector3.forward * 0);
            

        } else if(direction == 1)
        {
            GameObject first = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            GameObject second;
            GameObject third;
            if (PlayerPrefs.GetInt("SpearGun") >= 2)
            {
                second = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                third = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);

                second.transform.rotation = Quaternion.Euler(Vector3.forward * -25);
                third.transform.rotation = Quaternion.Euler(Vector3.forward * -65);
            }
            first.transform.rotation = Quaternion.Euler(Vector3.forward * -45);
            
        } else if(direction == 2)
        {
            GameObject first = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            GameObject second;
            GameObject third;
            if (PlayerPrefs.GetInt("SpearGun") >= 2)
            {
                second = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                third = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);

                second.transform.rotation = Quaternion.Euler(Vector3.forward * -70);
                third.transform.rotation = Quaternion.Euler(Vector3.forward * -110);
            }
            first.transform.rotation = Quaternion.Euler(Vector3.forward * -90);
            
        } else if(direction == 3)
        {
            GameObject first = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            GameObject second;
            GameObject third;
            if (PlayerPrefs.GetInt("SpearGun") >= 2)
            {
                second = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                third = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);

                second.transform.rotation = Quaternion.Euler(Vector3.forward * -115);
                third.transform.rotation = Quaternion.Euler(Vector3.forward * -155);
            }
            first.transform.rotation = Quaternion.Euler(Vector3.forward * -135);
            
        } else if(direction == 4)
        {
            GameObject first = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            GameObject second;
            GameObject third;
            if (PlayerPrefs.GetInt("SpearGun") >= 2)
            {
                second = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                third = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);

                second.transform.rotation = Quaternion.Euler(Vector3.forward * -160);
                third.transform.rotation = Quaternion.Euler(Vector3.forward * -200);
            }
            first.transform.rotation = Quaternion.Euler(Vector3.forward * -180);
            
        } else if(direction == 5)
        {
            GameObject first = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            GameObject second;
            GameObject third;
            if (PlayerPrefs.GetInt("SpearGun") >= 2)
            {
                second = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                third = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);

                second.transform.rotation = Quaternion.Euler(Vector3.forward * -205);
                third.transform.rotation = Quaternion.Euler(Vector3.forward * -245);
            }
            first.transform.rotation = Quaternion.Euler(Vector3.forward * -225);
            
        } else if(direction == 6)
        {
            GameObject first = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            GameObject second;
            GameObject third;
            if (PlayerPrefs.GetInt("SpearGun") >= 2)
            {
                second = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                third = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);

                second.transform.rotation = Quaternion.Euler(Vector3.forward * -250);
                third.transform.rotation = Quaternion.Euler(Vector3.forward * -290);
            }
            first.transform.rotation = Quaternion.Euler(Vector3.forward * -270);
            
        } else
        {
            GameObject first = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
            GameObject second;
            GameObject third;
            if (PlayerPrefs.GetInt("SpearGun") >= 2)
            {
                second = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);
                third = Instantiate(ProjectilePrefab, gameObject.transform.position, transform.rotation);

                second.transform.rotation = Quaternion.Euler(Vector3.forward * -295);
                third.transform.rotation = Quaternion.Euler(Vector3.forward * -335);
            }
            first.transform.rotation = Quaternion.Euler(Vector3.forward * -315);
            
        }
    }
}
