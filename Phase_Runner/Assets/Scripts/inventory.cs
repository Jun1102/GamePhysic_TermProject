using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot
{
    public hint_data hint;
    public int slot_index;
}
public class inventory : MonoBehaviour
{
    public static inventory instance;
    public ItemSlot[] slots;
    public itemslotUI[] uiSlots;
    private change_inventory slot_info;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        slots = new ItemSlot[uiSlots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            slots[i].slot_index = i;
        }
            
    }

    public void AddItem(hint_data hint)
    {
        ItemSlot empty_slot = GetEmptySlot();
        
        if (empty_slot != null)
        {
            empty_slot.hint = hint;
            UpdateUI();
        }
    }

	public string GetHintName()
	{
		ItemSlot current_slot = GetSelectedSlot();
		if (current_slot.hint != null)
			return current_slot.hint.hint_name;
		return null;
	}

	public Sprite GetHintContent()
    {
        ItemSlot current_slot = GetSelectedSlot();
        if(current_slot.hint != null)
            return current_slot.hint.content;
        return null;
    }
    public ItemSlot GetSelectedSlot()
    {
        Vector3 cur_slot = change_inventory.MoveSlot(change_inventory.cur_slot);
        int i = 0;
        while (true)
         {
            if (change_inventory.slot_pos[i] == cur_slot)
            {
                return slots[i];
            }
            i++;
         }
    }

    ItemSlot GetEmptySlot()
    {
        int i = 0;
        while (true)
        {
            if (slots[i].hint == null)
                return slots[i];
            if (i == 5)
                return null;
            i++;
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("UpdateUI");
            if (slots[i].hint != null)
                uiSlots[i].SetUI(slots[i]);
        }
    }

    
}
