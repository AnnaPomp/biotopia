using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
   
    public string InventoryName;
    public List<Slots_UI> slots = new List<Slots_UI>();
    [SerializeField] private Canvas canvas;
    
    private bool dragSingle;

    private Inventar inventory;


    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }
    private void Start()
    {
        inventory = GameManager.instance.player.inventory.GetInvByName(InventoryName);

        if (inventory == null)
        {
            Debug.LogError("Inventory not found: " + InventoryName);
            return;
        }
        SetupSlots();
        Refresh();    
    }
   

   
 

  public  void Refresh()
    {
        if (slots.Count == inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }

        }
        
    }
    public void Remove()
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItembyName
            (inventory.slots[Ui_manager.draggedSlot.SlotId].itemName);
        if(itemToDrop!=null)
        {
            if (Ui_manager.dragSingle)
            {
               GameManager.instance.player. DropItem(itemToDrop);
                inventory.Remove(Ui_manager.draggedSlot.SlotId);
            }
            else
            {
                GameManager.instance.player.DropItem(itemToDrop, inventory.slots[Ui_manager.draggedSlot.SlotId].numar);
                inventory.Remove(Ui_manager.draggedSlot.SlotId, inventory.slots[Ui_manager.draggedSlot.SlotId].numar);
            }
           
            Refresh();
        }

        Ui_manager.draggedSlot = null;
       
    }

    public void SlotBeginDrag(Slots_UI slot)
    {
        Ui_manager.draggedSlot = slot;
        Ui_manager. draggedIcon = Instantiate(slot.itemIcon);
        Ui_manager. draggedIcon.transform.SetParent(canvas.transform);
        Ui_manager.draggedIcon.raycastTarget = false;
        Ui_manager. draggedIcon.rectTransform.sizeDelta = new Vector2(100, 100); // Ajustează dimensiunea după nevoie
        Ui_manager.draggedIcon.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        Ui_manager.draggedIcon.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        Ui_manager. draggedIcon.rectTransform.pivot = new Vector2(0.5f, 0.5f);

        MoveToMousePos(Ui_manager.draggedIcon.gameObject);
       // Debug.Log("Start Drag:" + Ui_manager.draggedSlot.name);
    } 
    
    public void SlotDrag()
    {
        MoveToMousePos(Ui_manager.draggedIcon.gameObject);

       // Debug.Log("Dragging" + Ui_manager.draggedSlot.name);
    }
    public void SlotEndDrag()
    {
        Destroy(Ui_manager.draggedIcon.gameObject);
        Ui_manager.draggedIcon = null;

        //Debug.Log("Dragging Finished" + Ui_manager.draggedSlot.name);

    }

    public void SlotDrop(Slots_UI slot)
    {
        Ui_manager.draggedSlot. inventory.MoveSlot(Ui_manager.draggedSlot.SlotId, slot.SlotId,slot.inventory);
        //Refresh();
        //Debug.Log("Dropped" + Ui_manager.draggedSlot.name + "on" + slot.name);
        GameManager.instance.uiManager.RefreshAll();
    }

    private void MoveToMousePos(GameObject toMove)
    {
            if(canvas!=null)
        {
            Vector2 pozitie;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
                Input.mousePosition, null, out pozitie);
            toMove.transform.position = canvas.transform.TransformPoint(pozitie);
        }
    }

    void SetupSlots()
    {
        int counter = 0;
        foreach(Slots_UI slot in slots)
        {
            slot.SlotId = counter;
            counter++;
            slot.inventory = inventory;
        }
    }

}
