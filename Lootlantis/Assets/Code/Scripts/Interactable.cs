using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Interactable : MonoBehaviour
{

    public bool isActive;

    public GameObject interactIcon;

    public void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public abstract void Interact();

    private void OnTriggerEnter2d(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OpenInteractIcon();
        }
    }

    private void OnTriggerExit2d(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CloseInteractIcon();
        }
    }

    public void OpenInteractIcon()
    {
        interactIcon.SetActive(true);
    }

    public void CloseInteractIcon()
    {
        interactIcon.SetActive(false);
    }
}
