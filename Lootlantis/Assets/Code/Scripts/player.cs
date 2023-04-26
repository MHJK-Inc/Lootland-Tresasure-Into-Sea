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

    SpriteRenderer PlayerSpriteRenderer;

    //Health Bar setting
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject bar;
    public Quaternion rot;

    public float damageTimer = 0f;
    public float damageDecreaseRate = 1f;

    public float inventory = 0;

    public bool paused;

    //Game Over Screen
    public GameOver gameManager;
    public Paused gamePause;

    //Interact Icon

    public Interactable objective;

    public AudioSource aud;
    public AudioClip damageAud;
    public AudioClip healAud;

    public bool invincible = false;

    public AudioSource but;
    public AudioClip buttonClick;

    //Animator
    Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        damageTimer = 100f;

        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();

        inventory = GetInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.timeScale != 0f)
        {
            ProcessInputs();

            if(Input.GetKeyDown(KeyCode.N))
            {
                TakeDamage(20);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                if(objective != null)
                {
                    CheckInteraction();
                }
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(!paused)
                {
                    but.PlayOneShot(buttonClick);
                    paused = true;
                    gamePause.pause();
                }
            }
        }

        else {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(paused)
                {
                    gamePause.unpause();
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

            if(damageTimer >= 1f){
                damageTimer--;
            } else {
                currentHealth = currentHealth - 2; 

                healthBar.SetHealth(currentHealth);

                if (currentHealth <= 0)
                {
                    gameManager.gameOver();
                    //Destroy(gameObject);
                    //gameObject.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                damageTimer = 100f;
            }
        }

    }

    public float GetInventory() {
        if(PlayerPrefs.GetInt("Inventory1") == 0) {
            return 0;
        } else if (PlayerPrefs.GetInt("Inventory2") == 0) {
            return 1;
        } else if (PlayerPrefs.GetInt("Inventory3") == 0) {
            return 2;
        } else {
            return 3;
        }
    }

    public IEnumerator FlashAfterDamage()
    {
        invincible = true;
        float flashDelay = 0.0833f;
        for (int i = 0; i < 5; i++)
        {
            PlayerSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashDelay);
            PlayerSpriteRenderer.enabled = true;
            yield return new WaitForSeconds(flashDelay);
        }
        invincible = false;
    }

    public void TakeDamage(int damage)
    {
        if(!invincible) {
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
    }

    public void HealDamage(int heal)
    {
        if ((currentHealth + heal) > maxHealth)
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        } else
        {
            currentHealth = currentHealth + heal;
            healthBar.SetHealth(currentHealth);
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
            // 4/17/23 Edited by Michael
            gameObject.transform.localScale = new Vector3(3, 3, 1);
            bar.transform.localScale = new Vector3(1, 1, 1);
        } else if (moveX < 0){
            gameObject.transform.localScale = new Vector3(-3, 3, 1);
            bar.transform.localScale = new Vector3(-1, 1, 1);
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        if(moveDirection.x < 0 ){ //left
            //gameObject.transform.localRotation = Quaternion.Euler(0,0,90);
            //bar.transform.localRotation = Quaternion.Euler(0,0,90);
            animator.SetBool("isMovingRight", true);
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingUp", false);
            PlayerSpriteRenderer.flipX = true;
        } else if(moveDirection.x > 0 ){ // right
            //gameObject.transform.localRotation = Quaternion.Euler(0,0,-90);
            //bar.transform.localRotation = Quaternion.Euler(0,0,90);
            animator.SetBool("isMovingRight", true);
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingUp", false);
            PlayerSpriteRenderer.flipX = true;
        } else if(moveDirection.y < 0 ){ //down
            //gameObject.transform.localRotation = Quaternion.Euler(0,0,180);
            //bar.transform.localRotation = Quaternion.Euler(0,0,-180);
            animator.SetBool("isMovingDown", true);
            animator.SetBool("isMovingUp", false);
            animator.SetBool("isMovingRight", false);
            PlayerSpriteRenderer.flipX = false;
        } else if(moveDirection.y > 0 ){ // up
            //gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
            //bar.transform.localRotation = Quaternion.Euler(0,0,0);
            animator.SetBool("isMovingUp", true);
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingDown", false);
            PlayerSpriteRenderer.flipX = false;
        }
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
        } else if (collider.gameObject.CompareTag("Enemy Projectile"))
        {
            StartCoroutine(FlashAfterDamage());

        } else if (collider.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(FlashAfterDamage());

        } else if (collider.gameObject.CompareTag("Boss Projectile"))
        {
            StartCoroutine(FlashAfterDamage());

        }
    }

}
