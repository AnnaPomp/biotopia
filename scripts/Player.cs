using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory_man inventory;

    private TileManager tileManager;
   
    private void Start()
    {
        tileManager = GameManager.instance.tileManager;
    }
    private void Awake()
    {
        inventory = GetComponent<Inventory_man>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(tileManager!=null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x,
                               (int)transform.position.y, 0);
                string tileName = tileManager.GetTileName(position);
                Debug.Log("Tile at position " + position + " has name: " + tileName);
                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if (tileName == "Interactable"&& inventory.hotbar.selectedSlot.itemName=="Hoe")
                    {
                        tileManager.SetInteracted(position);
                        Debug.Log("Tile interaction successful at " + position);
                        //Debug.Log("Tile at " + position + " is named: " + tileName);
                    }
                   
                }
            }



           
        }
    }
    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;
        Vector3 spawnOffset = Random.insideUnitCircle * 1.25f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset,
            Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnOffset * .01f, ForceMode2D.Impulse);
        
    }
    public void DropItem(Item item,int numToDrop)
    {
      for(int i=0;i<numToDrop;i++)
        {
            DropItem(item);
        }

    }
    private void GainGold(int amount)
    {
        GameManager.instance.goldEvents.GoldGained(amount);
    }

    private void ChangeGold(int amount)
    {
        GameManager.instance.goldEvents.GoldChange(amount);
    }



}
