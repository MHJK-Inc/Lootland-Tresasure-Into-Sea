using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    public GameObject can;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public GameObject spearGun;
    public GameObject fireball;
    public GameObject barrier;
    string[] weapons = {"SpearGun", "Fireball", "Barrier"};
    GameObject player;


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
                Debug.Log("L was pressed");
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
            if (weapon == null && player.GetComponent<Player>().inventory < 6)
            {
                weaponPool[index] = weapons[i];
                index++;
            } else if (weapon) {
                if (weapon.GetComponent<Weapon>().level < 8) {
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
            buttonOne.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "N/A";
            buttonTwo.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "N/A";
            buttonThree.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "N/A";
            SpawnUpgrade(0);
        } else if (index == 1) {
            buttonTwo.SetActive(false);
            buttonThree.SetActive(false);
            buttonOne.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = weaponPool[choiceOne];
            buttonTwo.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "N/A";
            buttonThree.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "N/A";
        } else if (index == 2) {
            buttonThree.SetActive(false);
            buttonOne.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = weaponPool[choiceOne];
            buttonTwo.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = weaponPool[choiceTwo];
            buttonThree.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "N/A";
        } else if (index == 3) {
            buttonOne.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = weaponPool[choiceOne];
            buttonTwo.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = weaponPool[choiceTwo];
            buttonThree.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = weaponPool[choiceThree];
        }

        





    }

    public void SpawnUpgrade(int var)
    {
        GameObject weapon = null;
        if(var == 1) {
            string str = buttonOne.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            weapon = GameObject.Find(str);
            if (weapon == null)
            {
                AddWeapon(str);
            } else {
                weapon.GetComponent<Weapon>().level++;
            }
        } else if(var == 2) {
            string str = buttonTwo.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            weapon = GameObject.Find(str);
            if (weapon == null)
            {
                AddWeapon(str);
            } else {
                weapon.GetComponent<Weapon>().level++;
            }
        }  else if(var == 3) {
            string str = buttonThree.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            weapon = GameObject.Find(str);
            if (weapon == null)
            {
                AddWeapon(str);
            } else {
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

        } else if (str.Equals("Barrier"))
        {
            Instantiate(barrier, gameObject.transform.position, transform.rotation);
            weapon = GameObject.Find("Barrier(Clone)");
            if (weapon) {
                weapon.name = "Barrier";
            }
        }
    }
}


