using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            int add = 1 + PlayerPrefs.GetInt("Currency");
            PlayerPrefs.SetInt("Currency", (PlayerPrefs.GetInt("Currency") + add));
            Destroy(gameObject);
        }
        
    }
}
