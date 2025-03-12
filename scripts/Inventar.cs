using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventar 
{
    [System.Serializable]
    public class Slot
    {
        public string itemName;
        public int numar;
        public int maximnr;
        public Sprite icon;
        public Slot()
        {
            itemName = "";
           numar = 0;
            maximnr = 99;
        }

        public bool isEmpty
        {
            get 
            { 
                if(itemName==""&&numar==0)
                {
                    return true;
                }
                return false;
                }
        }

        public bool canAddItem(string itemName)
        {
            if(this.itemName==itemName&& numar<maximnr)
            { 
                return true; 
            }
            return false;
        }
        public void AddItem(Item item)
        {
            this.itemName = item.data.ItemName;
            this.icon = item.data.icon;
            numar++;
        }
        public void AddItem(string itemName, Sprite icon, int maxAllowed )
        {
            this.itemName = itemName;
            this.icon = icon;

            numar++;
            this.maximnr = maximnr;
        }
        public void RemoveItem()
        {
            if(numar>0)
            {
                numar--;
                if(numar==0)
                {
                    icon = null;
                    itemName = "";
                }
            }
        }

    }
    public List<Slot> slots = new List<Slot>();
    public Slot selectedSlot = null;
    public Inventar(int numSlot)
    {
 for(int i=0;i<numSlot;i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }
    public void Add(Item item)
    {
foreach(Slot slot in slots)
        {
            if (slot.itemName == item.data.ItemName && slot.canAddItem(item.data.ItemName))
            {
                slot.AddItem(item);
                return;
            }
        }
foreach(Slot slot in slots)
        {
            if(slot.itemName=="")
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Remove(int index)
    {
        if (index >= 0 && index < slots.Count)
        {
            slots[index].RemoveItem();
        }
    }
    public void Remove(int index,int numToRem)
    {
      if(slots[index].numar>=numToRem)
        {
            for(int i=0;i<numToRem;i++)
            {
                Remove(index);
            }
        }    
    }

    public void MoveSlot(int fromIndex,int toIndex, Inventar toInv)
    {
        Slot fromSlot = slots[fromIndex];
        Slot toSlot = toInv.slots[toIndex];
        if(toSlot.isEmpty ||toSlot.canAddItem(fromSlot.itemName))
{
            toSlot.AddItem(fromSlot.itemName, fromSlot.icon, fromSlot.maximnr);
            fromSlot.RemoveItem();
        }
    }

    public void SelectedSlot(int index)
    {
        if(slots!=null&&slots.Count>0)
        {
            selectedSlot = slots[index];
        }
    }

}
