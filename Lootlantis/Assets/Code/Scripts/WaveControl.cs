using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveControl : MonoBehaviour
{
    public float TimeLeft;
    public float EnemiesLeft;
    public bool TimerOn;
    public TMPro.TextMeshProUGUI TimerTxt;
    public TMPro.TextMeshProUGUI KillTxt;
    public WaveClear waveClear;
    // Start is called before the first frame update

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    public GameObject obj7;
    public GameObject obj8;
    public GameObject obj9;
    public GameObject obj10;
    public GameObject obj11;
    public GameObject obj12;
    public GameObject obj13;
    public GameObject obj14;
    public GameObject obj15;
    public GameObject obj16;

    public GameObject player;

    public GameObject levelUp;

    public Slider slider;

    public bool waveBeat;

    public float quarterTime;
    public float halfTime;
    public float threeFourthTime;

    public GameObject enemyControl;
    public GameObject shootEnemyControl;
    public GameObject serpentEnemyControl;


    


    void Start()
    {
        Time.timeScale = 1f;
        SetUp();
        TimerOn = true;
        waveBeat = false;
        DecideObjectives();
        int bonus = (PlayerPrefs.GetInt("Health")) * 30;
        float speedBonus = (PlayerPrefs.GetInt("Movement")) * 0.6f;
        player.GetComponent<Player>().maxHealth = player.GetComponent<Player>().maxHealth + bonus;
        player.GetComponent<Player>().currentHealth = player.GetComponent<Player>().maxHealth;
        player.GetComponent<Player>().moveSpeed = player.GetComponent<Player>().moveSpeed + speedBonus;
        slider.maxValue = player.GetComponent<Player>().maxHealth;
        slider.value = player.GetComponent<Player>().maxHealth;
        SpawnWeapons();
        
        

        //different wave settings in a method
        //method to randomize active objectives
        //set wave timer (1 min?)
        //set enemies left (10?)
        //End round if either hit 0
        //Call Level Up
        //Call to next wave
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            Timer();
            UpdateKill();
            if(waveBeat == true) {
                Time.timeScale = 0f;
            }
            
        }
    }

    private void spawnControl()
    {
        SpawnEnemy en = enemyControl.GetComponent<SpawnEnemy>();
        SpawnShootingEnemy sen = shootEnemyControl.GetComponent<SpawnShootingEnemy>();
        SpawnSerpent serpen = serpentEnemyControl.GetComponent<SpawnSerpent>();
        int wave = PlayerPrefs.GetInt("Wave");
        if (wave == 1) {
            if (TimeLeft > quarterTime) {
                en.maxEnemyCount = 3;
                en.spawnInterval = 3;

            } else if (TimeLeft > halfTime) {
                en.maxEnemyCount = 5;
                en.spawnInterval = 3;

            } else if (TimeLeft > threeFourthTime) {
                en.maxEnemyCount = 7;
                en.spawnInterval = 3;

            } else {
                en.maxEnemyCount = 10;
                en.spawnInterval = 3;

            }
        } else if (wave == 2) {
            if (TimeLeft > quarterTime) {
                en.maxEnemyCount = 5;
                en.spawnInterval = 3;
                sen.maxEnemyCount = 1;
                sen.spawnInterval = 5;

            } else if (TimeLeft > halfTime) {
                en.maxEnemyCount = 7;
                en.spawnInterval = 3;
                sen.maxEnemyCount = 2;
                sen.spawnInterval = 5;

            } else if (TimeLeft > threeFourthTime) {
                en.maxEnemyCount = 10;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 3;
                sen.spawnInterval = 5;

            } else {
                en.maxEnemyCount = 13;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 4;
                sen.spawnInterval = 5;
                
            }

        } else if (wave == 3) { 
            if (TimeLeft > quarterTime) {
                en.maxEnemyCount = 10;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 2;
                sen.spawnInterval = 5;

            } else if (TimeLeft > halfTime) {
                en.maxEnemyCount = 13;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 3;
                sen.spawnInterval = 5;

            } else if (TimeLeft > threeFourthTime) {
                en.maxEnemyCount = 15;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 4;
                sen.spawnInterval = 5;

            } else {
                en.maxEnemyCount = 17;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 6;
                sen.spawnInterval = 5;
                
            }
        } else if (wave == 4) { 
            if (TimeLeft > quarterTime) {
                en.maxEnemyCount = 15;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 3;
                sen.spawnInterval = 5;
                serpen.maxEnemyCount = 3;
                serpen.spawnInterval = 1;

            } else if (TimeLeft > halfTime) {
                en.maxEnemyCount = 17;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 5;
                sen.spawnInterval = 5;
                serpen.maxEnemyCount = 5;
                serpen.spawnInterval = 1;

            } else if (TimeLeft > threeFourthTime) {
                en.maxEnemyCount = 20;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 7;
                sen.spawnInterval = 5;
                serpen.maxEnemyCount = 7;
                serpen.spawnInterval = 1;

            } else {
                en.maxEnemyCount = 25;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 10;
                sen.spawnInterval = 5;
                serpen.maxEnemyCount = 10;
                serpen.spawnInterval = 3;
                
            }
        } else if (wave == 5) { 
            if (TimeLeft > quarterTime) {
                en.maxEnemyCount = 20;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 6;
                sen.spawnInterval = 5;
                serpen.maxEnemyCount = 6;
                serpen.spawnInterval = 1;

            } else if (TimeLeft > halfTime) {
                en.maxEnemyCount = 25;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 8;
                sen.spawnInterval = 5;
                serpen.maxEnemyCount = 10;
                serpen.spawnInterval = 1;

            } else if (TimeLeft > threeFourthTime) {
                en.maxEnemyCount = 30;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 10;
                sen.spawnInterval = 5;
                serpen.maxEnemyCount = 12;
                serpen.spawnInterval = 1;

            } else {
                en.maxEnemyCount = 35;
                en.spawnInterval = 5;
                sen.maxEnemyCount = 12;
                sen.spawnInterval = 5;
                serpen.maxEnemyCount = 15;
                serpen.spawnInterval = 1;
                
            }
        } else {

        }

    }

    private void SetUp()
    {
        
        if (PlayerPrefs.GetInt("Wave") == 1)
        {
            TimeLeft = 120;
            EnemiesLeft = 15;
            quarterTime = 90;
            halfTime = 60;
            threeFourthTime = 30;
            enemyControl.SetActive(true);
            shootEnemyControl.SetActive(false);
            serpentEnemyControl.SetActive(false);
            
        } else if (PlayerPrefs.GetInt("Wave") == 2)
        {
            TimeLeft = 180;
            EnemiesLeft = 30;
            quarterTime = 135;
            halfTime = 90;
            threeFourthTime = 45;
            enemyControl.SetActive(true);
            shootEnemyControl.SetActive(true);
            serpentEnemyControl.SetActive(false);

        }else if (PlayerPrefs.GetInt("Wave") == 3)
        {
            TimeLeft = 240;
            EnemiesLeft = 50;
            quarterTime = 180;
            halfTime = 120;
            threeFourthTime = 60;
            enemyControl.SetActive(true);
            shootEnemyControl.SetActive(true);
            serpentEnemyControl.SetActive(false);

        }else if (PlayerPrefs.GetInt("Wave") == 4)
        {
            TimeLeft = 300;
            EnemiesLeft = 100;
            quarterTime = 225;
            halfTime = 150;
            threeFourthTime = 75;
            enemyControl.SetActive(true);
            shootEnemyControl.SetActive(true);
            serpentEnemyControl.SetActive(true);

        } else if (PlayerPrefs.GetInt("Wave") == 5)
        {
            TimeLeft = 360;
            EnemiesLeft = 200;
            quarterTime = 270;
            halfTime = 180;
            threeFourthTime = 90;
            enemyControl.SetActive(true);
            shootEnemyControl.SetActive(true);
            serpentEnemyControl.SetActive(true);

        } else {
            TimeLeft = 1000;
            EnemiesLeft = 1;
            quarterTime = 750;
            halfTime = 500;
            threeFourthTime = 250;
            //enemyControl.SetActive(false);
            //shootEnemyControl.SetActive(false);
            //serpentEnemyControl.SetActive(false);

        }

        
    }



    void Timer()
    {
        if(TimerOn)
        {
            if(PlayerPrefs.GetInt("Wave") < 6)
            {
                if (TimeLeft > 0)
                {
                    TimeLeft -= Time.deltaTime;
                    UpdateTimer(TimeLeft);
                } else {
                    if(waveBeat == false){
                        waveBeat = true;
                        levelUp.GetComponent<LevelUp>().Level();
                        waveClear.Clear();
                    }
                }
            }  
        } 
    }

    void UpdateTimer(float currentTime)
    {
        if(PlayerPrefs.GetInt("Wave") < 6)
        {
            currentTime += 1;

            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            TimerTxt.text = string.Format("Survive For: {0:00} : {1:00}", minutes, seconds);
        } else {
            TimerTxt.text = string.Format("Survive!");
        }
    }

    void UpdateKill()
    {
        if(PlayerPrefs.GetInt("Wave") < 6)
        {
            if(EnemiesLeft > 0) {
                KillTxt.text = string.Format("Enemies Remaining: " + EnemiesLeft);
            } else
            {
                if(waveBeat == false){
                    waveBeat = true;
                    levelUp.GetComponent<LevelUp>().Level();
                    waveClear.Clear();
                }
            }
        } else {
            if(EnemiesLeft > 0) {
                KillTxt.text = string.Format("Enemies Remaining: " + EnemiesLeft);
            } else
            {
                if(waveBeat == false){
                    waveBeat = true;
                    waveClear.Clear();
                }
            }
        }
    }

    void SpawnWeapons()
    {
        int spearGun = PlayerPrefs.GetInt("SpearGun");
        int fireBall = PlayerPrefs.GetInt("Fireball");
        int emp = PlayerPrefs.GetInt("EMP");
        int barrier = PlayerPrefs.GetInt("Barrier");
        int harpoonGun = PlayerPrefs.GetInt("HarpoonGun");
        int mine = PlayerPrefs.GetInt("Mine");
        int laser = PlayerPrefs.GetInt("Laser");
        if(spearGun > 0)
        {
            for(int i = 0; i < spearGun - 1; i++)
            {
                GameObject.Find("SpearGun").GetComponent<SpearGun>().level = spearGun;
            }

        }

        if(fireBall > 0)
        {
            levelUp.GetComponent<LevelUp>().AddWeapon("Fireball");
            for(int i = 0; i < fireBall- 1; i++)
            {
                GameObject.Find("Fireball").GetComponent<Fireball>().level++;
            }
        }

        if(emp > 0)
        {
            levelUp.GetComponent<LevelUp>().AddWeapon("EMP");
            for(int i = 0; i < emp - 1; i++)
            {
                GameObject.Find("EMP").GetComponent<EMP>().level++;
            }
        }

        if(barrier > 0)
        {
            levelUp.GetComponent<LevelUp>().AddWeapon("Barrier");
            for(int i = 0; i < barrier - 1; i++)
            {
                GameObject.Find("Barrier").GetComponent<Barrier>().level++;
            }
        }

        if(harpoonGun > 0)
        {
            levelUp.GetComponent<LevelUp>().AddWeapon("HarpoonGun");
            for(int i = 0; i < harpoonGun - 1; i++)
            {
                GameObject.Find("HarpoonGun").GetComponent<HarpoonGun>().level++;
            }
        }

        if(mine > 0)
        {
            levelUp.GetComponent<LevelUp>().AddWeapon("Mine");
            for(int i = 0; i < mine - 1; i++)
            {
                GameObject.Find("Mine").GetComponent<Mine>().level++;
            }
        }

        if(laser > 0)
        {
            levelUp.GetComponent<LevelUp>().AddWeapon("Laser");
            for(int i = 0; i < laser - 1; i++)
            {
                GameObject.Find("Laser").GetComponent<Laser>().level++;
            }
        }

        
    }

    void DecideObjectives()
    {
        if(PlayerPrefs.GetInt("Wave") < 6)
        {
            int choice = 0;
            List<GameObject> groupOne = new List<GameObject> {obj1, obj2, obj3, obj4};
            List<GameObject> groupTwo = new List<GameObject> {obj5, obj6, obj7, obj8};
            List<GameObject> groupThree = new List<GameObject> {obj9, obj10, obj11, obj12};
            List<GameObject> groupFour = new List<GameObject> {obj13, obj14, obj15, obj16};
            choice = Random.Range(0, 3);
            groupOne[choice].SetActive(true);
            groupTwo[choice].SetActive(false);
            groupThree[choice].SetActive(false);
            groupFour[choice].SetActive(false);

            groupOne.RemoveAt(choice);
            groupTwo.RemoveAt(choice);
            groupThree.RemoveAt(choice);
            groupFour.RemoveAt(choice);

            choice = Random.Range(0, 2);

            groupOne[choice].SetActive(false);
            groupTwo[choice].SetActive(true);
            groupThree[choice].SetActive(false);
            groupFour[choice].SetActive(false);

            groupOne.RemoveAt(choice);
            groupTwo.RemoveAt(choice);
            groupThree.RemoveAt(choice);
            groupFour.RemoveAt(choice);

            choice = Random.Range(0, 1);

            groupOne[choice].SetActive(false);
            groupTwo[choice].SetActive(false);
            groupThree[choice].SetActive(true);
            groupFour[choice].SetActive(false);

            groupOne.RemoveAt(choice);
            groupTwo.RemoveAt(choice);
            groupThree.RemoveAt(choice);
            groupFour.RemoveAt(choice);

            choice = 0;

            groupOne[choice].SetActive(false);
            groupTwo[choice].SetActive(false);
            groupThree[choice].SetActive(false);
            groupFour[choice].SetActive(true);

            groupOne.RemoveAt(choice);
            groupTwo.RemoveAt(choice);
            groupThree.RemoveAt(choice);
            groupFour.RemoveAt(choice);
        }

    }
}
