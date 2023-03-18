using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public Transform Player;
    public GameOver gameManager;
    private bool isDead;

    public void SetHealth(int health){
        slider.value = health;
    }

    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position + transform.up * 0.8f;
        if (Time.timeScale != 0f)
        {
            // if (slider.value <= 0 && !isDead)
            // {
            //     //Debug.Log("DEAD");
            //     //isDead = true;
            //     //gameManager.gameOver();
            // }
        }
    }
}
