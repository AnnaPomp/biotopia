using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<Slots_UI> toolbarSlots= new List<Slots_UI>();
    private Slots_UI selectedSlot;

    private void Start()
    {
        SelectedSlot(0);
    }
    private void Update()
    {
        CheckAlphaNumericKeys();
    }
    public void SelectedSlot(Slots_UI slot)
    {
        SelectedSlot(slot.SlotId);
    }
    public void SelectedSlot(int index)
    {
        if(toolbarSlots.Count==9)
        {
            if(selectedSlot!=null)
            {
                selectedSlot.SetHightlight(false);
            }

            selectedSlot = toolbarSlots[index];
            selectedSlot.SetHightlight(true);
            //Debug.Log("Selected slot: " + selectedSlot.name);
            GameManager.instance.player.inventory.hotbar.SelectedSlot(index);
        }
    }
    private void CheckAlphaNumericKeys()
    {
if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectedSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectedSlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectedSlot(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectedSlot(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectedSlot(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SelectedSlot(8);
        }

    }
}
