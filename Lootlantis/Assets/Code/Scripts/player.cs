using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb; 
    private Vector2 moveDirection;
    public float facing = 2f;
    // 0 up, 1 up right, 2 right, 3 down right
    // 4 down, 5 down left, 6 left, 7 up left

    //Health Bar setting
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

    }

    // FixedUpdate is called one per frame, but fixed to a universal time, not based on frame rate I think
    void FixedUpdate()
    {
        Move();

    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage; 

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Calculate Direction
        if(moveX == 0 && moveY > 0)
        {
            facing = 0f;
        } else if (moveX > 0 && moveY > 0)
        {
            facing = 1f;
        } else if (moveX > 0 && moveY == 0)
        {
            facing = 2f;
        } else if (moveX > 0 && moveY < 0)
        {
            facing = 3f;
        } else if (moveX == 0 && moveY < 0)
        {
            facing = 4f;
        } else if (moveX < 0 && moveY < 0)
        {
            facing = 5f;
        } else if (moveX < 0 && moveY == 0)
        {
            facing = 6f;
        } else if (moveX < 0 && moveY > 0)
        {
            facing = 7f;
        }



        if(moveX > 0) {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        } else if (moveX < 0){
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}
