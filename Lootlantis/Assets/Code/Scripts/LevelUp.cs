using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUp : MonoBehaviour
{
    public GameObject can;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public GameObject spearGun;
    public GameObject fireball;
    public GameObject emp;
    public GameObject barrier;
    public GameObject harpoonGun;
    public GameObject mine;
    public GameObject laser;
    string[] weapons = {"SpearGun", "Fireball", "EMP", "Barrier", "HarpoonGun", "Mine", "Laser"};
    GameObject player;
    public TextMeshProUGUI choiceOneText;
    public TextMeshProUGUI choiceTwoText;
    public TextMeshProUGUI choiceThreeText;

    public TextMeshProUGUI choiceOneDesc;
    public TextMeshProUGUI choiceTwoDesc;
    public TextMeshProUGUI choiceThreeDesc;
    public Image choiceOneImg;
    public Image choiceTwoImg;
    public Image choiceThreeImg;
    public Sprite spearGunImg;
    public Sprite fireballImg;
    public Sprite empImg;
    public Sprite barrierImg;
    public Sprite harpoonGunImg;
    public Sprite mineImg;
    public Sprite laserImg;
    public Sprite emptyImg;
    public AudioSource but;
    public AudioClip buttonClick;

    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject emp1;
    public GameObject emp2;
    public GameObject emp3;
    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject barrier3;
    public GameObject harpoon1;
    public GameObject harpoon2;
    public GameObject harpoon3;
    public GameObject mine1;
    public GameObject mine2;
    public GameObject mine3;
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject empty1;
    public GameObject empty2;
    public GameObject empty3;

    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            if(Input.GetKeyDown(KeyCode.L))
            {
                Level();
            }
        }
    }

    public void Level()
    {
        can.SetActive(true);
        string[] weaponPool = new string[weapons.Length];
        int index = 0;
        int random = -1;
        int choiceOne = -1;
        int choiceTwo = -1;
        int choiceThree = -1;
        GameObject weapon = null;

        Time.timeScale = 0f;

        for(int i = 0; i < weapons.Length; i++) 
        {
            weapon = GameObject.Find(weapons[i]);
            if (weapon == null && PlayerPrefs.GetInt("Inventory") < 3)
            {
                weaponPool[index] = weapons[i];
                index++;
            } else if (weapon) {
                if (PlayerPrefs.GetInt(weapons[i]) < 3) {
                    weaponPool[index] = weapons[i];
                    index++;
                }
            }
        }


        if (index > 0)
        {
            choiceOne = Random.Range(0, index);
        }
        

        if (index > 1)
        {
            while (choiceTwo == -1) {
                random = Random.Range(0, index);
                if (random != choiceOne)
                {
                    choiceTwo = random;
                }
            }

        }

        if (index > 2)
        {
            while (choiceThree == -1) {
                random = Random.Range(0, index);
                if (random != choiceOne && random != choiceTwo)
                {
                    choiceThree = random;
                }
            }
        }

        if (index == 0) {
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            buttonThree.SetActive(false);
            choiceOneImg.enabled = false;
            choiceTwoImg.enabled = false;
            choiceThreeImg.enabled = false;
            choiceOneDesc.text = "N/A";
            choiceTwoDesc.text = "N/A";
            choiceThreeDesc.text = "N/A";
            choiceOneText.text = "N/A";
            choiceTwoText.text = "N/A";
            choiceThreeText.text = "N/A";
            SpawnUpgrade(0);
        } else if (index == 1) {
            buttonTwo.SetActive(false);
            buttonThree.SetActive(false);
            choiceTwoImg.enabled = false;
            choiceThreeImg.enabled = false;
            choiceTwoDesc.text = "N/A";
            choiceThreeDesc.text = "N/A";;
            choiceOneText.text = weaponPool[choiceOne];
            choiceTwoText.text = "N/A";
            choiceThreeText.text = "N/A";
            ShowInfo(choiceOneText.text, "none", "none");
        } else if (index == 2) {
            buttonThree.SetActive(false);
            choiceThreeImg.enabled = false;
            choiceThreeDesc.text = "N/A";
            choiceOneText.text = weaponPool[choiceOne];
            choiceTwoText.text = weaponPool[choiceTwo];
            choiceThreeText.text = "N/A";
            ShowInfo(choiceOneText.text, choiceTwoText.text, "none");
        } else if (index > 2) {
            choiceOneText.text = weaponPool[choiceOne];
            choiceTwoText.text = weaponPool[choiceTwo];
            choiceThreeText.text = weaponPool[choiceThree];
            ShowInfo(choiceOneText.text, choiceTwoText.text, choiceThreeText.text);
        }

        





    }

    public int GetNum(string str) {
        //"SpearGun", "Fireball", "EMP", "Barrier", "HarpoonGun", "Mine", "Laser"
        if (str == "SpearGun") {
            return 0;
        } else if (str == "Fireball") {
            return 1;
        } else if (str == "EMP") {
            return 2;
        } else if (str == "Barrier") {
            return 3;
        } else if (str == "HarpoonGun") {
            return 4;
        } else if (str == "Mine") {
            return 5;
        } else if (str == "Laser") {
            return 6;
        }
        return 0;
    }

    public void setImage(int slot, int weapon) {
        if (slot == 1) {
            if(weapon == 1) {
                fire1.SetActive(true);
                emp1.SetActive(false);
                barrier1.SetActive(false);
                harpoon1.SetActive(false);
                mine1.SetActive(false);
                laser1.SetActive(false);
                empty1.SetActive(false);
            } else if(weapon == 2) {
                fire1.SetActive(false);
                emp1.SetActive(true);
                barrier1.SetActive(false);
                harpoon1.SetActive(false);
                mine1.SetActive(false);
                laser1.SetActive(false);
                empty1.SetActive(false);
            } else if(weapon == 3) {
                fire1.SetActive(false);
                emp1.SetActive(false);
                barrier1.SetActive(true);
                harpoon1.SetActive(false);
                mine1.SetActive(false);
                laser1.SetActive(false);
                empty1.SetActive(false);
            } else if(weapon == 4) {
                fire1.SetActive(false);
                emp1.SetActive(false);
                barrier1.SetActive(false);
                harpoon1.SetActive(true);
                mine1.SetActive(false);
                laser1.SetActive(false);
                empty1.SetActive(false);
            } else if(weapon == 5) {
                fire1.SetActive(false);
                emp1.SetActive(false);
                barrier1.SetActive(false);
                harpoon1.SetActive(false);
                mine1.SetActive(true);
                laser1.SetActive(false);
                empty1.SetActive(false);
            }
             else if(weapon == 6) {
                fire1.SetActive(false);
                emp1.SetActive(false);
                barrier1.SetActive(false);
                harpoon1.SetActive(false);
                mine1.SetActive(false);
                laser1.SetActive(true);
                empty1.SetActive(false);
            }
        } else if (slot == 2) {
            if(weapon == 1) {
                fire2.SetActive(true);
                emp2.SetActive(false);
                barrier2.SetActive(false);
                harpoon2.SetActive(false);
                mine2.SetActive(false);
                laser2.SetActive(false);
                empty2.SetActive(false);
            } else if(weapon == 2) {
                fire2.SetActive(false);
                emp2.SetActive(true);
                barrier2.SetActive(false);
                harpoon2.SetActive(false);
                mine2.SetActive(false);
                laser2.SetActive(false);
                empty2.SetActive(false);
            } else if(weapon == 3) {
                fire2.SetActive(false);
                emp2.SetActive(false);
                barrier2.SetActive(true);
                harpoon2.SetActive(false);
                mine2.SetActive(false);
                laser2.SetActive(false);
                empty2.SetActive(false);
            } else if(weapon == 4) {
                fire2.SetActive(false);
                emp2.SetActive(false);
                barrier2.SetActive(false);
                harpoon2.SetActive(true);
                mine2.SetActive(false);
                laser2.SetActive(false);
                empty2.SetActive(false);
            } else if(weapon == 5) {
                fire2.SetActive(false);
                emp2.SetActive(false);
                barrier2.SetActive(false);
                harpoon2.SetActive(false);
                mine2.SetActive(true);
                laser2.SetActive(false);
                empty2.SetActive(false);
            }
             else if(weapon == 6) {
                fire2.SetActive(false);
                emp2.SetActive(false);
                barrier2.SetActive(false);
                harpoon2.SetActive(false);
                mine2.SetActive(false);
                laser2.SetActive(true);
                empty2.SetActive(false);
            }
        } else if (slot == 3) {
            if(weapon == 1) {
                fire3.SetActive(true);
                emp3.SetActive(false);
                barrier3.SetActive(false);
                harpoon3.SetActive(false);
                mine3.SetActive(false);
                laser3.SetActive(false);
                empty3.SetActive(false);
            } else if(weapon == 2) {
                fire3.SetActive(false);
                emp3.SetActive(true);
                barrier3.SetActive(false);
                harpoon3.SetActive(false);
                mine3.SetActive(false);
                laser3.SetActive(false);
                empty3.SetActive(false);
            } else if(weapon == 3) {
                fire3.SetActive(false);
                emp3.SetActive(false);
                barrier3.SetActive(true);
                harpoon3.SetActive(false);
                mine3.SetActive(false);
                laser3.SetActive(false);
                empty3.SetActive(false);
            } else if(weapon == 4) {
                fire3.SetActive(false);
                emp3.SetActive(false);
                barrier3.SetActive(false);
                harpoon3.SetActive(true);
                mine3.SetActive(false);
                laser3.SetActive(false);
                empty3.SetActive(false);
            } else if(weapon == 5) {
                fire3.SetActive(false);
                emp3.SetActive(false);
                barrier3.SetActive(false);
                harpoon3.SetActive(false);
                mine3.SetActive(true);
                laser3.SetActive(false);
                empty3.SetActive(false);
            }
             else if(weapon == 6) {
                fire3.SetActive(false);
                emp3.SetActive(false);
                barrier3.SetActive(false);
                harpoon3.SetActive(false);
                mine3.SetActive(false);
                laser3.SetActive(true);
                empty3.SetActive(false);
            }
        }
    }

    public void SpawnUpgrade(int var)
    {
        but.PlayOneShot(buttonClick);
        GameObject weapon = null;
        if(var == 1) {
            string str = choiceOneText.text;
            weapon = GameObject.Find(str);
            if (weapon == null)
            {
                if(PlayerPrefs.GetInt("Inventory1") == 0) {
                    PlayerPrefs.SetInt("Inventory1", GetNum(str));
                    setImage(1, GetNum(str));
                } else if(PlayerPrefs.GetInt("Inventory2") == 0) {
                    PlayerPrefs.SetInt("Inventory2", GetNum(str));
                    setImage(2, GetNum(str));
                } else {
                    PlayerPrefs.SetInt("Inventory3", GetNum(str));
                    setImage(3, GetNum(str));
                }
                PlayerPrefs.SetInt("Inventory", PlayerPrefs.GetInt("Inventory") + 1);
                PlayerPrefs.SetInt(str, 1);
                AddWeapon(str);
            } else {
                PlayerPrefs.SetInt(str, (PlayerPrefs.GetInt(str) + 1));
                weapon.GetComponent<Weapon>().level++;
            }
        } else if(var == 2) {
            string str = choiceTwoText.text;
            weapon = GameObject.Find(str);
            Debug.Log(weapon);
            if (weapon == null)
            {
                if(PlayerPrefs.GetInt("Inventory1") == 0) {
                    PlayerPrefs.SetInt("Inventory1", GetNum(str));
                    setImage(1, GetNum(str));
                } else if(PlayerPrefs.GetInt("Inventory2") == 0) {
                    PlayerPrefs.SetInt("Inventory2", GetNum(str));
                    setImage(2, GetNum(str));
                } else {
                    PlayerPrefs.SetInt("Inventory3", GetNum(str));
                    setImage(3, GetNum(str));
                }
                PlayerPrefs.SetInt("Inventory", PlayerPrefs.GetInt("Inventory") + 1);
                PlayerPrefs.SetInt(str, 1);
                AddWeapon(str);
            } else {
                PlayerPrefs.SetInt(str, (PlayerPrefs.GetInt(str) + 1));
                weapon.GetComponent<Weapon>().level++;
            }
        }  else if(var == 3) {
            string str = choiceThreeText.text;
            weapon = GameObject.Find(str);
            Debug.Log(weapon);
            if (weapon == null)
            {
                if(PlayerPrefs.GetInt("Inventory1") == 0) {
                    PlayerPrefs.SetInt("Inventory1", GetNum(str));
                    setImage(1, GetNum(str));
                } else if(PlayerPrefs.GetInt("Inventory2") == 0) {
                    PlayerPrefs.SetInt("Inventory2", GetNum(str));
                    setImage(2, GetNum(str));
                } else {
                    PlayerPrefs.SetInt("Inventory3", GetNum(str));
                    setImage(3, GetNum(str));
                }
                PlayerPrefs.SetInt("Inventory", PlayerPrefs.GetInt("Inventory") + 1);
                PlayerPrefs.SetInt(str, 1);
                AddWeapon(str);
            } else {
                PlayerPrefs.SetInt(str, (PlayerPrefs.GetInt(str) + 1));
                weapon.GetComponent<Weapon>().level++;
            }
        }

        can.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AddWeapon(string str) {
        GameObject weapon;
        if (str.Equals("SpearGun"))
        {
            Instantiate(spearGun, gameObject.transform.position, transform.rotation);
            weapon = GameObject.Find("SpearGun(Clone)");
            if (weapon) {
                weapon.name = "SpearGun";
            }
        }
        else if (str.Equals("Fireball"))
        {
            Instantiate(fireball, gameObject.transform.position, transform.rotation);
            weapon = GameObject.Find("Fireball(Clone)");
            if (weapon) {
                weapon.name = "Fireball";
            }

        } else if (str.Equals("EMP"))
        {
            Instantiate(emp, gameObject.transform.position, transform.rotation);
            weapon = GameObject.Find("EMP(Clone)");
            if (weapon) {
                weapon.name = "EMP";
            }
        } else if (str.Equals("Barrier"))
        {
            Instantiate(barrier, gameObject.transform.position, transform.rotation);
            weapon = GameObject.Find("Barrier(Clone)");
            if (weapon) {
                weapon.name = "Barrier";
            }
        } else if (str.Equals("HarpoonGun"))
        {
            Instantiate(harpoonGun, gameObject.transform.position, transform.rotation);
            weapon = GameObject.Find("HarpoonGun(Clone)");
            if (weapon) {
                weapon.name = "HarpoonGun";
            }
        } else if (str.Equals("Mine"))
        {
            Instantiate(mine, gameObject.transform.position, transform.rotation);
            weapon = GameObject.Find("Mine(Clone)");
            if (weapon) {
                weapon.name = "Mine";
            }
        } else if (str.Equals("Laser"))
        {
            Instantiate(laser, gameObject.transform.position, transform.rotation);
            weapon = GameObject.Find("Laser(Clone)");
            if (weapon) {
                //Debug.Log("Laser Created");
                weapon.name = "Laser";
            }
        }
    }

    public void ShowInfo(string cOne, string cTwo, string cThree) {

        if (cOne.Equals("SpearGun"))
        {
            choiceOneImg.sprite = spearGunImg;
            if (PlayerPrefs.GetInt("SpearGun") == 0) {
                choiceOneDesc.text = "Fires a single shot in front of you with the Spacebar.";
            } else if(PlayerPrefs.GetInt("SpearGun") == 1) {
                choiceOneDesc.text = "Level 2: Deals double damage.";
            } else {
                choiceOneDesc.text = "Level 3: Fires a spread of 3 shots now.";
            }
        }
        else if (cOne.Equals("Fireball"))
        {
            choiceOneImg.sprite = fireballImg;
            if (PlayerPrefs.GetInt("Fireball") == 0) {
                choiceOneDesc.text = "Fires homing attacks at the enemy.";
            } else if(PlayerPrefs.GetInt("Fireball") == 1) {
                choiceOneDesc.text = "Level 2: Increases fire rate.";
            } else {
                choiceOneDesc.text = "Level 3: Fireballs explode on impact, dealing extra damage to enemies in the area.";
            }
        } else if (cOne.Equals("EMP"))
        {
            choiceOneImg.sprite = empImg;
            if (PlayerPrefs.GetInt("EMP") == 0) {
                choiceOneDesc.text = "Deals damage in a circle around the player.";
            } else if(PlayerPrefs.GetInt("EMP") == 1) {
                choiceOneDesc.text = "Level 2: Radius of circle increases.";
            } else {
                choiceOneDesc.text = "Level 3: Radius of circle increases again.";
            }
        } else if (cOne.Equals("Barrier"))
        {
            choiceOneImg.sprite = barrierImg;
            if (PlayerPrefs.GetInt("Barrier") == 0) {
                choiceOneDesc.text = "Circles around player and damages any enemies it hits. Stops normal enemy projectiles.";
            } else if(PlayerPrefs.GetInt("Barrier") == 1) {
                choiceOneDesc.text = "Level 2: Increase barrier size.";
            } else {
                choiceOneDesc.text = "Level 3: Get two circles of protection instead of one.";
            }
        } else if (cOne.Equals("HarpoonGun"))
        {
            choiceOneImg.sprite = harpoonGunImg;
            if (PlayerPrefs.GetInt("HarpoonGun") == 0) {
                choiceOneDesc.text = "Slower fire rate, stronger projectiles. Can pierce through 3 enemies.";
            } else if(PlayerPrefs.GetInt("HarpoonGun") == 1) {
                choiceOneDesc.text = "Level 2: Can pierce through 5 enemies now.";
            } else {
                choiceOneDesc.text = "Level 3: Fire rate increased.";
            }
        } else if (cOne.Equals("Mine"))
        {
            choiceOneImg.sprite = mineImg;
            if (PlayerPrefs.GetInt("Mine") == 0) {
                choiceOneDesc.text = "Places a mine down that explodes over time or on touching an enemy. Explodes into shrapnel that also damage enemies.";
            } else if(PlayerPrefs.GetInt("Mine") == 1) {
                choiceOneDesc.text = "Level 2: Damage from mine and shrapnel increased.";
            } else {
                choiceOneDesc.text = "Level 3: Number of shrapnel doubled.";
            }
        } else if (cOne.Equals("Laser"))
        {
            choiceOneImg.sprite = laserImg;
            if (PlayerPrefs.GetInt("Laser") == 0) {
                choiceOneDesc.text = "Charges and fires a laser in the direction the player is facing. Deals more damage the longer it stays on an enemy.";
            } else if(PlayerPrefs.GetInt("Laser") == 1) {
                choiceOneDesc.text = "Level 2: Increases fire rate.";
            } else {
                choiceOneDesc.text = "Level 3: Increases damage and duration of laser.";
            }
        } else
        {
            choiceOneImg.sprite = emptyImg;
            choiceOneDesc.text = "";
        }

        if (cTwo.Equals("SpearGun"))
        {
            choiceTwoImg.sprite = spearGunImg;
            if (PlayerPrefs.GetInt("SpearGun") == 0) {
                choiceTwoDesc.text = "Fires a single shot in front of you with the Spacebar.";
            } else if(PlayerPrefs.GetInt("SpearGun") == 1) {
                choiceTwoDesc.text = "Level 2: Deals double damage.";
            } else {
                choiceTwoDesc.text = "Level 3: Fires a spread of 3 shots now.";
            }
        }
        else if (cTwo.Equals("Fireball"))
        {
            choiceTwoImg.sprite = fireballImg;
            if (PlayerPrefs.GetInt("Fireball") == 0) {
                choiceTwoDesc.text = "Fires homing attacks at the enemy.";
            } else if(PlayerPrefs.GetInt("Fireball") == 1) {
                choiceTwoDesc.text = "Level 2: Doubles fire rate.";
            } else {
                choiceTwoDesc.text = "Level 3: Fireballs explode on impact, dealing extra damage to enemies in the area.";
            }
        } else if (cTwo.Equals("EMP"))
        {
            choiceTwoImg.sprite = empImg;
            if (PlayerPrefs.GetInt("EMP") == 0) {
                choiceTwoDesc.text = "Deals damage in a circle around the player.";
            } else if(PlayerPrefs.GetInt("EMP") == 1) {
                choiceTwoDesc.text = "Level 2: Radius of circle increases.";
            } else {
                choiceTwoDesc.text = "Level 3: Radius of circle increases again.";
            }
        } else if (cTwo.Equals("Barrier"))
        {
            choiceTwoImg.sprite = barrierImg;
            if (PlayerPrefs.GetInt("Barrier") == 0) {
                choiceTwoDesc.text = "Circles around player and damages any enemies it hits. Stops normal enemy projectiles.";
            } else if(PlayerPrefs.GetInt("Barrier") == 1) {
                choiceTwoDesc.text = "Level 2: Increase barrier size.";
            } else {
                choiceTwoDesc.text = "Level 3: Get two circles of protection instead of one.";
            }
        } else if (cTwo.Equals("HarpoonGun"))
        {
            choiceTwoImg.sprite = harpoonGunImg;
            if (PlayerPrefs.GetInt("HarpoonGun") == 0) {
                choiceTwoDesc.text = "Slower fire rate, stronger projectiles. Can pierce through 3 enemies.";
            } else if(PlayerPrefs.GetInt("HarpoonGun") == 1) {
                choiceTwoDesc.text = "Level 2: Can pierce through 5 enemies now.";
            } else {
                choiceTwoDesc.text = "Level 3: Fire rate increased.";
            }
        } else if (cTwo.Equals("Mine"))
        {
            choiceTwoImg.sprite = mineImg;
            if (PlayerPrefs.GetInt("Mine") == 0) {
                choiceTwoDesc.text = "Places a mine down that explodes over time or on touching an enemy. Explodes into shrapnel that also damage enemies.";
            } else if(PlayerPrefs.GetInt("Mine") == 1) {
                choiceTwoDesc.text = "Level 2: Damage from mine and shrapnel increased.";
            } else {
                choiceTwoDesc.text = "Level 3: Number of shrapnel doubled.";
            }
        } else if (cTwo.Equals("Laser"))
        {
            choiceTwoImg.sprite = laserImg;
            if (PlayerPrefs.GetInt("Laser") == 0) {
                choiceTwoDesc.text = "Charges and fires a laser in the direction the player is facing. Deals more damage the longer it stays on an enemy.";
            } else if(PlayerPrefs.GetInt("Laser") == 1) {
                choiceTwoDesc.text = "Level 2: Increases fire rate.";
            } else {
                choiceTwoDesc.text = "Level 3: Increases damage and duration of laser.";
            }
        } else
        {
            choiceTwoImg.sprite = emptyImg;
            choiceTwoDesc.text = "";
        }

        if (cThree.Equals("SpearGun"))
        {
            choiceThreeImg.sprite = spearGunImg;
            if (PlayerPrefs.GetInt("SpearGun") == 0) {
                choiceThreeDesc.text = "Fires a single shot in front of you with the Spacebar.";
            } else if(PlayerPrefs.GetInt("SpearGun") == 1) {
                choiceThreeDesc.text = "Level 2: Deals double damage.";
            } else {
                choiceThreeDesc.text = "Level 3: Fires a spread of 3 shots now.";
            }
        }
        else if (cThree.Equals("Fireball"))
        {
            choiceThreeImg.sprite = fireballImg;
            if (PlayerPrefs.GetInt("Fireball") == 0) {
                choiceThreeDesc.text = "Fires homing attacks at the enemy.";
            } else if(PlayerPrefs.GetInt("Fireball") == 1) {
                choiceThreeDesc.text = "Level 2: Doubles fire rate.";
            } else {
                choiceThreeDesc.text = "Level 3: Fireballs explode on impact, dealing extra damage to enemies in the area.";
            }
        } else if (cThree.Equals("EMP"))
        {
            choiceThreeImg.sprite = empImg;
            if (PlayerPrefs.GetInt("EMP") == 0) {
                choiceThreeDesc.text = "Deals damage in a circle around the player.";
            } else if(PlayerPrefs.GetInt("EMP") == 1) {
                choiceThreeDesc.text = "Level 2: Radius of circle increases.";
            } else {
                choiceThreeDesc.text = "Level 3: Radius of circle increases again.";
            }
        } else if (cThree.Equals("Barrier"))
        {
            choiceThreeImg.sprite = barrierImg;
            if (PlayerPrefs.GetInt("Barrier") == 0) {
                choiceThreeDesc.text = "Circles around player and damages any enemies it hits. Stops normal enemy projectiles.";
            } else if(PlayerPrefs.GetInt("Barrier") == 1) {
                choiceThreeDesc.text = "Level 2: Increase barrier size.";
            } else {
                choiceThreeDesc.text = "Level 3: Get two circles of protection instead of one.";
            }
        } else if (cThree.Equals("HarpoonGun"))
        {
            choiceThreeImg.sprite = harpoonGunImg;
            if (PlayerPrefs.GetInt("HarpoonGun") == 0) {
                choiceThreeDesc.text = "Slower fire rate, stronger projectiles. Can pierce through 3 enemies.";
            } else if(PlayerPrefs.GetInt("HarpoonGun") == 1) {
                choiceThreeDesc.text = "Level 2: Can pierce through 5 enemies now.";
            } else {
                choiceThreeDesc.text = "Level 3: Fire rate increased.";
            }
        } else if (cThree.Equals("Mine"))
        {
            choiceThreeImg.sprite = mineImg;
            if (PlayerPrefs.GetInt("Mine") == 0) {
                choiceThreeDesc.text = "Places a mine down that explodes over time or on touching an enemy. Explodes into shrapnel that also damage enemies.";
            } else if(PlayerPrefs.GetInt("Mine") == 1) {
                choiceThreeDesc.text = "Level 2: Damage from mine and shrapnel increased.";
            } else {
                choiceThreeDesc.text = "Level 3: Number of shrapnel doubled.";
            }
        } else if (cThree.Equals("Laser"))
        {
            choiceThreeImg.sprite = laserImg;
            if (PlayerPrefs.GetInt("Laser") == 0) {
                choiceThreeDesc.text = "Charges and fires a laser in the direction the player is facing. Deals more damage the longer it stays on an enemy.";
            } else if(PlayerPrefs.GetInt("Laser") == 1) {
                choiceThreeDesc.text = "Level 2: Increases fire rate.";
            } else {
                choiceThreeDesc.text = "Level 3: Increases damage and duration of laser.";
            }
        } else
        {
            choiceThreeImg.sprite = emptyImg;
            choiceThreeDesc.text = "";
        }

        //Copy paste for cTwo and cThree
    }
}


