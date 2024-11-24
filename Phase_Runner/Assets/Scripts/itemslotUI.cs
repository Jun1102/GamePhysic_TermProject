using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemslotUI : MonoBehaviour
{
    public ItemSlot Curslot;
    public Image icon;
    private enable_hint onHint;

    private void Start()
    {
        icon = GetComponent<Image>();
    }

    public void SetUI(ItemSlot slot)
    {
        Curslot = slot;
        icon.sprite = slot.hint.icon;
    }
}
