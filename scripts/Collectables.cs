using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class Collectables : MonoBehaviour
{
    private XPman xpManager;

    private void Start()
    {
        // Căutăm scriptul XPman în scenă
        xpManager = FindObjectOfType<XPman>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            // Adăugăm XP când obiectul este colectat
            if (xpManager != null)
            {
                xpManager.Addxp(61);  // Crește XP-ul cu 10 (poți schimba valoarea după nevoie)
            }

            // Adăugăm itemul în inventar
            Item item = GetComponent<Item>();
            if (item != null)
            {
                player.inventory.Add("Backpack", item);
                Destroy(this.gameObject);  // Distruge obiectul colectabil
            }
        }
    }
}
