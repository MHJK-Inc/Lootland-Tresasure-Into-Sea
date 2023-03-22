using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]

public class MoneyChest : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;

    public GameObject moneyTxt;

    public bool showMoney;
    public bool countMoney;

    private byte count;

    public override void Interact()
    {
        if (isActive)
        {
            isActive = false;
            sr.sprite = open;
            PlayerPrefs.SetInt("Currency", (PlayerPrefs.GetInt("Currency") + 100));
            showMoney = true;
        }
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
        isActive = true;
        interactIcon.SetActive(false);
        showMoney = false;
        countMoney = false;
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            if(showMoney)
            {
                interactIcon.SetActive(false);
                moneyTxt.SetActive(true);
                count = 255;
                countMoney = true;
                showMoney = false;
            }

            if(countMoney)
            {
                if (count > 0)
                {
                    count--;
                } else
                {
                    moneyTxt.SetActive(false);
                    countMoney = false;
                }
            }

        }
    }

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
        isActive = true;
    }


}

