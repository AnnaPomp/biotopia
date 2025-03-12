using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_manager : MonoBehaviour
{

    public Dictionary<string, Inventory_UI> inventoryUIByName = new Dictionary<string, Inventory_UI>();

    public GameObject invPan;
    public List<Inventory_UI> inventoryUI;
    public static  Slots_UI draggedSlot;
    public static Image draggedIcon;
    public static bool dragSingle;


    private void Awake()
    {
        Initialize(); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInv();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dragSingle = true;
        }
        else
        { dragSingle = false; }
    }
    public void ToggleInv()
    {
        if (invPan != null)
        {
            if (!invPan.activeSelf)
            {
                invPan.SetActive(true);
                RefreshInventoryUI("Backpack");
            }
            else
            {
                invPan.SetActive(false);
            }
        }

    }
    public void RefreshInventoryUI(string inventoryName)
    {
if(inventoryUIByName.ContainsKey(inventoryName))
        {
            inventoryUIByName[inventoryName].Refresh();
        }
    }
    public void RefreshAll()
    {
foreach(KeyValuePair<string,Inventory_UI>keyValuePairin in inventoryUIByName)
        {
            keyValuePairin.Value.Refresh();
        }
    }

    public Inventory_UI GetInvUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }
        
        return null; 
    }

     void Initialize()
    {
     foreach(Inventory_UI ui in inventoryUI)
        {
            if(!inventoryUIByName.ContainsKey(ui.InventoryName))
            {
                inventoryUIByName.Add(ui.InventoryName, ui);
            }
        }
    }
}
