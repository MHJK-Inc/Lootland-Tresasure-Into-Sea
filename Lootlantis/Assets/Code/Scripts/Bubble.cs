using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
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
            collide.gameObject.GetComponent<Player>().HealDamage(1);
            Destroy(gameObject);
        }
        
    }
}
