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

    public float damageTimer = 0f;
    public float damageDecreaseRate = 1f;

    public int inventory = 0;

    //Game Over Screen
    public GameOver gameManager;

    //Interact Icon


    public Interactable objective;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.timeScale != 0f)
        {
            ProcessInputs();

            damageTimer += Time.deltaTime;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
            }

            if(damageTimer >= 1f){
                TakeDamage(1);
                damageTimer = 0f;
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                if(objective != null)
                {
                    CheckInteraction();
                }
            }
        }
    }

    // FixedUpdate is called one per frame, but fixed to a universal time, not based on frame rate I think
    void FixedUpdate()
    {
        if (Time.timeScale != 0f)
        {
            Move();
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage; 

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            gameManager.gameOver();
            //Destroy(gameObject);
            //gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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

    private void CheckInteraction()
    {
        objective.Interact();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Objective"))
        {
            objective = collider.gameObject.GetComponent<Interactable>(); 
            if (objective.isActive)
            {
                objective.OpenInteractIcon();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Objective"))
        {
            objective.CloseInteractIcon();
        }
    }

}
