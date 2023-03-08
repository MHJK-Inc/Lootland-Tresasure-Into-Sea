using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

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
        if (slider.value <= 0 && !isDead)
        {
            Debug.Log("DEAD");
            isDead = true;
            gameManager.gameOver();
        }
    }
}
