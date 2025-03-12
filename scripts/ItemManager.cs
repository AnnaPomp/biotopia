using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DICTIONAR CARE CONTINE TOATE ELEMENTELE COLLECTABLES
public class ItemManager : MonoBehaviour
{
    public Item[] items;
    private Dictionary<string, Item> nametoitemDict = 
        new Dictionary<string, Item>();
    private void Awake()
    {
        foreach(Item item in items)
        {
            AddItem(item);
        }
    }
    public void AddItem(Item item)
    {
        if(!nametoitemDict.ContainsKey(item.data.ItemName))
        {
            nametoitemDict.Add(item.data.ItemName, item);
        }
    }

    public Item GetItembyName(string key)
    {
        
        if (nametoitemDict.ContainsKey(key))
        {
            
            return nametoitemDict[key];
        }
        
           // Debug.LogWarning($"Item of type {type} not found in collectableItemsDict!");
            return null;
        
    }

}
