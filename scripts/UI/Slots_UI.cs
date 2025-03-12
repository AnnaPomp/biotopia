using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots_UI : MonoBehaviour
{
    public int SlotId;
    public Inventar inventory;
   public Image itemIcon;
   public TextMeshProUGUI Quantity;
    [SerializeField] private GameObject highlight;
    public void SetItem(Inventar.Slot slot)
    {
        if(slot!=null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            Quantity.text = slot.numar.ToString();
        }
    }
    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        Quantity.text = "";
    }

    public void SetHightlight(bool isOn)
    {
        highlight.SetActive(isOn);
    }

}
