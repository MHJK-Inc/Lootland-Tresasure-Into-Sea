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
    public float maxHitPoints = 10;
    public float laserTick;
    public float laserPower;

    private Serpent serpent;
    private SpawnSerpent spawnSerpent;
    public AudioSource aud;
    public AudioClip audPlayerHit;
    public AudioClip enemyHit;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemy";

        spawnSerpent = FindObjectOfType<SpawnSerpent>();
        SetHealth();
        hitPoints = maxHitPoints;
        serpent = FindObjectOfType<Serpent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMarkerList();
    }

    public void SetHealth()
    {

        if (PlayerPrefs.GetInt("Wave") == 1)
        {
            //maxHitPoints = maxHitPoints * (1 + ((PlayerPrefs.GetInt("Wave") - 1) * 0.2) + ((spawnSerpent.totalWeapons - 1) * 0.2f));
        }
        else if (PlayerPrefs.GetInt("Wave") == 2)
        {
            //maxHitPoints = maxHitPoints * (1 + ((PlayerPrefs.GetInt("Wave") - 1) * 0.2) + ((spawnSerpent.totalWeapons - 1) * 0.2f));
        }
        else if (PlayerPrefs.GetInt("Wave") == 3)
        {
            //maxHitPoints = maxHitPoints * (1 + ((PlayerPrefs.GetInt("Wave") - 1) * 0.2) + ((spawnSerpent.totalWeapons - 1) * 0.2f));
        }
        else if (PlayerPrefs.GetInt("Wave") == 4)
        {
            maxHitPoints = maxHitPoints * (1f + ((PlayerPrefs.GetInt("Wave") - 4f) * 0.2f) + ((spawnSerpent.totalWeapons - 1f) * 0.2f));
        }
        else
        {
            maxHitPoints = maxHitPoints * (1f + ((PlayerPrefs.GetInt("Wave") - 4f) * 0.4f) + ((spawnSerpent.totalWeapons - 1f) * 0.2f));
        }
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
        aud.PlayOneShot(enemyHit);
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            bool isDead = true;
            serpent.DestroySerpent(isDead);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            aud.PlayOneShot(audPlayerHit);
            collision.gameObject.GetComponent<Player>().TakeDamage(5);
        }
        
    }
}
