using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class TreasureChest : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;

    public AudioSource aud;
    public AudioClip chest;

    public override void Interact()
    {
        if (isActive)
        {
            aud.PlayOneShot(chest);
            isActive = false;
            sr.sprite = open;
            gameObject.transform.localScale = new Vector3(10, 10, 1);
            GameObject.Find("LevelUp").GetComponent<LevelUp>().Level();
            
        }
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gameObject.transform.localScale = new Vector3(10, 10, 1);
        sr.sprite = closed;
        isActive = true;
        interactIcon.SetActive(false);
    }

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
        isActive = true;
    }


}

