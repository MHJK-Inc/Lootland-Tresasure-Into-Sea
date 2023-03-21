using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpentManager : MonoBehaviour
{
    public class Marker
    {
        public Vector3 position;
        public Quaternion rotation;

        public Marker(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }

    public List<Marker> markerList = new List<Marker>();


    public HealthBarBehavior healthBar;
    public float hitPoints;
    public float maxHitPoints = 20;
    private Serpent serpent;
    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;
        serpent = FindObjectOfType<Serpent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMarkerList();
    }

    public void UpdateMarkerList()
    {
        markerList.Add(new Marker(transform.position, transform.rotation));
    }

    public void ClearMarkerList()
    {
        markerList.Clear();
        markerList.Add(new Marker(transform.position, transform.rotation));
    }

    public void TakeHit(float damage)
    {
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            bool isDead = hitPoints <= 0;
            serpent.DestroySerpent(isDead);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(5);
        }
        
    }
}
