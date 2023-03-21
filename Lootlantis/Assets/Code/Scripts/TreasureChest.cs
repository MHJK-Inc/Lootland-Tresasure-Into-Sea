using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class TreasureChest : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;

    public override void Interact()
    {
        if (isActive)
        {
            isActive = false;
            sr.sprite = open;
            GameObject.Find("LevelUp").GetComponent<LevelUp>().Level();
            
        }
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
