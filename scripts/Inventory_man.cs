using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_man : MonoBehaviour
{
    public Dictionary<string, Inventar> inventoryByName = new Dictionary<string, Inventar>();
    [Header("Backpack")]
    public Inventar backpack;
    public int backSlotCount;
    [Header("Toolbar")]
    public Inventar hotbar;
    public int hotbarSlotCount;
    private void Awake()
    {
        backpack = new Inventar(backSlotCount);
        hotbar = new Inventar(hotbarSlotCount);

        inventoryByName.Add("Backpack", backpack);
        inventoryByName.Add("Toolbar", hotbar);
    }
    public void Add(string inventoryName,Item item)
    {
        if(inventoryByName.ContainsKey(inventoryName))
        {
            inventoryByName[inventoryName].Add(item);
        }
    }

    public Inventar GetInvByName(string inventoryName)
    {
        if(inventoryByName.ContainsKey(inventoryName))
        {
            return inventoryByName[inventoryName];
        }
        return null;
    }
}
