using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]

public class Gate : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;

    public GameObject gateTxt;

    public bool showGate;
    public bool countGate;

    private byte count;

    public GameObject waveControl;

    public override void Interact()
    {
        if (isActive)
        {
            isActive = false;
            sr.sprite = open;
            showGate = true;
            waveControl.GetComponent<WaveControl>().TimeLeft -= 60;
            waveControl.GetComponent<WaveControl>().EnemiesLeft -= 20;
        }
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
        isActive = true;
        interactIcon.SetActive(false);
        showGate = false;
        countGate = false;
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            if(showGate)
            {
                interactIcon.SetActive(false);
                gateTxt.SetActive(true);
                count = 255;
                countGate = true;
                showGate = false;
            }

            if(countGate)
            {
                if (count > 0)
                {
                    count--;
                } else
                {
                    gateTxt.SetActive(false);
                    countGate = false;
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

