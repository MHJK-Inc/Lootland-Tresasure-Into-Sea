using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PowerUp : MonoBehaviour
{
    public Button movementBut;
    public Button attackSpeedBut;
    public Button healthBut;
    public Button goldBut;
    public Button strengthBut;

    public TMPro.TextMeshProUGUI currencyTxt;
    public TMPro.TextMeshProUGUI movementTxt;
    public TMPro.TextMeshProUGUI attackSpeedTxt;
    public TMPro.TextMeshProUGUI healthTxt;
    public TMPro.TextMeshProUGUI goldTxt;
    public TMPro.TextMeshProUGUI strengthTxt;

    public TMPro.TextMeshProUGUI movementButTxt;
    public TMPro.TextMeshProUGUI attackSpeedButTxt;
    public TMPro.TextMeshProUGUI healthButTxt;
    public TMPro.TextMeshProUGUI goldButTxt;
    public TMPro.TextMeshProUGUI strengthButTxt;

    public float movement;
    public float attackSpeed;
    public float health;
    public float gold;
    public float strength;

    public float movementCost;
    public float attackSpeedCost;
    public float healthCost;
    public float goldCost;
    public float strengthCost;

    public float currency;

    // Start is called before the first frame update
    void Start()
    {
        movementBut.interactable = false;
        attackSpeedBut.interactable = false;
        healthBut.interactable = false;
        goldBut.interactable = false;
        strengthBut.interactable = false;

        movement = PlayerPrefs.GetInt("Movement");
        attackSpeed = PlayerPrefs.GetInt("AttackSpeed");
        health = PlayerPrefs.GetInt("Health");
        gold = PlayerPrefs.GetInt("Gold");
        strength = PlayerPrefs.GetInt("Strength");

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.SetInt("Currency", (int) (PlayerPrefs.GetInt("Currency") + 10000));
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.SetInt("Currency", 0);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("Movement", 0);
            PlayerPrefs.SetInt("AttackSpeed", 0);
            PlayerPrefs.SetInt("Health", 0);
            PlayerPrefs.SetInt("Gold", 0);
            PlayerPrefs.SetInt("Strength", 0);
        }
            

        currency = PlayerPrefs.GetInt("Currency");
        movement = PlayerPrefs.GetInt("Movement");
        attackSpeed = PlayerPrefs.GetInt("AttackSpeed");
        health = PlayerPrefs.GetInt("Health");
        gold = PlayerPrefs.GetInt("Gold");
        strength = PlayerPrefs.GetInt("Strength");

        UpdateCurrency();
        UpdateMovement();
        UpdateAttackSpeed();
        UpdateHealth();
        UpdateGold();
        UpdateStrength();
        
    }

    public void Movement()
    {
        PlayerPrefs.SetInt("Movement", (int) (movement + 1));
        PlayerPrefs.SetInt("Currency", (int) (currency - movementCost));
    }

    public void AttackSpeed()
    {
        PlayerPrefs.SetInt("AttackSpeed", (int) (attackSpeed + 1));
        PlayerPrefs.SetInt("Currency", (int) (currency - attackSpeedCost));
    }

    public void Health()
    {
        PlayerPrefs.SetInt("Health", (int) (health + 1));
        PlayerPrefs.SetInt("Currency", (int) (currency - healthCost));
    }

    public void Gold()
    {
        PlayerPrefs.SetInt("Gold", (int) (gold + 1));
        PlayerPrefs.SetInt("Currency", (int) (currency - goldCost));
    }

    public void Strength()
    {
        PlayerPrefs.SetInt("Strength", (int) (strength + 1));
        PlayerPrefs.SetInt("Currency", (int) (currency - strengthCost));
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateCurrency()
    {
        if(currency < 1000)
        {
            currencyTxt.text = "Currency\n" + currency;
        } else if (currency < 1000000)
        {
            int thousands = (int) (currency / 1000);
            int less = (int) (currency % 1000);
            if(less < 10)
            {
                currencyTxt.text = "Currency\n" + thousands + ",00" + less;
            } else if (less < 100)
            {
                currencyTxt.text = "Currency\n" + thousands + ",0" + less;
            } else
            {
                currencyTxt.text = "Currency\n" + thousands + "," + less;
            }
        } else if (currency < 1000000000)
        {
            int millions = (int) (currency / 1000000);
            int remainder = (int) (currency - (millions * 1000000));
            int thousands = (int) (remainder / 1000);
            remainder = (int) (remainder - (thousands * 1000));
            string str = "Currency\n" + millions;
            if(thousands < 10)
            {
                str = str + ",00" + thousands; 
            } else if (thousands < 100)
            {
                str = str + ",0" + thousands;
            } else
            {
                str = str + "," + thousands;
            }

            if (remainder < 10)
            {
                str = str + ",00" + remainder;
            } else if ( remainder < 100)
            {
                str = str + ",0" + remainder;
            } else
            {
                str = str + "," + remainder;
            }
            currencyTxt.text = str;
        } else
        {
            currencyTxt.text = "Currency\n" + "999,999,999+";
        }
    }

    private void UpdateMovement()
    {
        if (movement == 0)
        {
            movementTxt.text = "[  ] [  ] [  ] [  ] [  ]";
            movementCost = 100;

            if (currency >= movementCost)
            {
                movementBut.interactable = true;
            } else {
                movementBut.interactable = false;
            }
        } else if (movement == 1)
        {
            movementTxt.text = "[x] [  ] [  ] [  ] [  ]";
            movementCost = 200;

            if (currency >= movementCost)
            {
                movementBut.interactable = true;
            } else {
                movementBut.interactable = false;
            }
        } else if (movement == 2)
        {
            movementTxt.text = "[x] [x] [  ] [  ] [  ]";
            movementCost = 400;

            if (currency >= movementCost)
            {
                movementBut.interactable = true;
            } else {
                movementBut.interactable = false;
            }
        } else if (movement == 3)
        {
            movementTxt.text = "[x] [x] [x] [  ] [  ]";
            movementCost = 600;

            if (currency >= movementCost)
            {
                movementBut.interactable = true;
            } else {
                movementBut.interactable = false;
            }
        } else if (movement == 4)
        {
            movementTxt.text = "[x] [x] [x] [x] [  ]";
            movementCost = 1000;

            if (currency >= movementCost)
            {
                movementBut.interactable = true;
            } else {
                movementBut.interactable = false;
            }
        } else
        {
            movementTxt.text = "[x] [x] [x] [x] [x]";
            movementBut.interactable = false;
        }
        if(movement == 5)
        {
            movementButTxt.text = "Sold Out";
        } else
        {
            movementButTxt.text = "Purchase (" + movementCost + ")";
        }
    }

    private void UpdateAttackSpeed()
    {
        if (attackSpeed == 0)
        {
            attackSpeedTxt.text = "[  ] [  ] [  ] [  ] [  ]";
            attackSpeedCost = 100;

            if (currency >= attackSpeedCost)
            {
                attackSpeedBut.interactable = true;
            } else {
                attackSpeedBut.interactable = false;
            }
        } else if (attackSpeed == 1)
        {
            attackSpeedTxt.text = "[x] [  ] [  ] [  ] [  ]";
            attackSpeedCost = 200;

            if (currency >= attackSpeedCost)
            {
                attackSpeedBut.interactable = true;
            } else {
                attackSpeedBut.interactable = false;
            }
        } else if (attackSpeed == 2)
        {
            attackSpeedTxt.text = "[x] [x] [  ] [  ] [  ]";
            attackSpeedCost = 400;

            if (currency >= attackSpeedCost)
            {
                attackSpeedBut.interactable = true;
            } else {
                attackSpeedBut.interactable = false;
            }
        } else if (attackSpeed == 3)
        {
            attackSpeedTxt.text = "[x] [x] [x] [  ] [  ]";
            attackSpeedCost = 600;

            if (currency >= attackSpeedCost)
            {
                attackSpeedBut.interactable = true;
            } else {
                attackSpeedBut.interactable = false;
            }
        } else if (attackSpeed == 4)
        {
            attackSpeedTxt.text = "[x] [x] [x] [x] [  ]";
            attackSpeedCost = 1000;

            if (currency >= attackSpeedCost)
            {
                attackSpeedBut.interactable = true;
            } else {
                attackSpeedBut.interactable = false;
            }
        } else
        {
            attackSpeedTxt.text = "[x] [x] [x] [x] [x]";
            attackSpeedBut.interactable = false;
        }
        if(attackSpeed == 5)
        {
            attackSpeedButTxt.text = "Sold Out";
        } else
        {
            attackSpeedButTxt.text = "Purchase (" + attackSpeedCost + ")";
        }
    }

    private void UpdateHealth()
    {
        if (health == 0)
        {
            healthTxt.text = "[  ] [  ] [  ] [  ] [  ]";
            healthCost = 100;

            if (currency >= healthCost)
            {
                healthBut.interactable = true;
            } else {
                healthBut.interactable = false;
            }
        } else if (health == 1)
        {
            healthTxt.text = "[x] [  ] [  ] [  ] [  ]";
            healthCost = 200;

            if (currency >= healthCost)
            {
                healthBut.interactable = true;
            } else {
                healthBut.interactable = false;
            }
        } else if (health == 2)
        {
            healthTxt.text = "[x] [x] [  ] [  ] [  ]";
            healthCost = 400;

            if (currency >= healthCost)
            {
                healthBut.interactable = true;
            } else {
                healthBut.interactable = false;
            }
        } else if (health == 3)
        {
            healthTxt.text = "[x] [x] [x] [  ] [  ]";
            healthCost = 600;

            if (currency >= healthCost)
            {
                healthBut.interactable = true;
            } else {
                healthBut.interactable = false;
            }
        } else if (health == 4)
        {
            healthTxt.text = "[x] [x] [x] [x] [  ]";
            healthCost = 1000;

            if (currency >= healthCost)
            {
                healthBut.interactable = true;
            } else {
                healthBut.interactable = false;
            }
        } else
        {
            healthTxt.text = "[x] [x] [x] [x] [x]";
            healthBut.interactable = false;
        }
        if(health == 5)
        {
            healthButTxt.text = "Sold Out";
        } else
        {
            healthButTxt.text = "Purchase (" + healthCost + ")";
        }
    }

    private void UpdateGold()
    {
        if (gold == 0)
        {
            goldTxt.text = "[  ] [  ] [  ] [  ] [  ]";
            goldCost = 100;

            if (currency >= goldCost)
            {
                goldBut.interactable = true;
            } else {
                goldBut.interactable = false;
            }
        } else if (gold == 1)
        {
            goldTxt.text = "[x] [  ] [  ] [  ] [  ]";
            goldCost = 200;

            if (currency >= goldCost)
            {
                goldBut.interactable = true;
            } else {
                goldBut.interactable = false;
            }
        } else if (gold == 2)
        {
            goldTxt.text = "[x] [x] [  ] [  ] [  ]";
            goldCost = 400;

            if (currency >= goldCost)
            {
                goldBut.interactable = true;
            } else {
                goldBut.interactable = false;
            }
        } else if (gold == 3)
        {
            goldTxt.text = "[x] [x] [x] [  ] [  ]";
            goldCost = 600;

            if (currency >= goldCost)
            {
                goldBut.interactable = true;
            } else {
                goldBut.interactable = false;
            }
        } else if (gold == 4)
        {
            goldTxt.text = "[x] [x] [x] [x] [  ]";
            goldCost = 1000;

            if (currency >= goldCost)
            {
                goldBut.interactable = true;
            } else {
                goldBut.interactable = false;
            }
        } else
        {
            goldTxt.text = "[x] [x] [x] [x] [x]";
            goldBut.interactable = false;
        }
        if(gold == 5)
        {
            goldButTxt.text = "Sold Out";
        } else
        {
            goldButTxt.text = "Purchase (" + goldCost + ")";
        }
    }

    private void UpdateStrength()
    {
        if (strength == 0)
        {
            strengthTxt.text = "[  ] [  ] [  ] [  ] [  ]";
            strengthCost = 100;

            if (currency >= strengthCost)
            {
                strengthBut.interactable = true;
            } else {
                strengthBut.interactable = false;
            }
        } else if (strength == 1)
        {
            strengthTxt.text = "[x] [  ] [  ] [  ] [  ]";
            strengthCost = 200;

            if (currency >= strengthCost)
            {
                strengthBut.interactable = true;
            } else {
                strengthBut.interactable = false;
            }
        } else if (strength == 2)
        {
            strengthTxt.text = "[x] [x] [  ] [  ] [  ]";
            strengthCost = 400;

            if (currency >= strengthCost)
            {
                strengthBut.interactable = true;
            } else {
                strengthBut.interactable = false;
            }
        } else if (strength == 3)
        {
            strengthTxt.text = "[x] [x] [x] [  ] [  ]";
            strengthCost = 600;

            if (currency >= strengthCost)
            {
                strengthBut.interactable = true;
            } else {
                strengthBut.interactable = false;
            }
        } else if (strength == 4)
        {
            strengthTxt.text = "[x] [x] [x] [x] [  ]";
            strengthCost = 1000;

            if (currency >= strengthCost)
            {
                strengthBut.interactable = true;
            } else {
                strengthBut.interactable = false;
            }
        } else
        {
            strengthTxt.text = "[x] [x] [x] [x] [x]";
            strengthBut.interactable = false;
        }
        if(strength == 5)
        {
            strengthButTxt.text = "Sold Out";
        } else
        {
            strengthButTxt.text = "Purchase (" + strengthCost + ")";
        }
    }
}
