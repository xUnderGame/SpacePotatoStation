using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlot {
    public InventorySlot(ScriptableSeed _type) {
        type = _type;
        quantity = 1;
    }
    public ScriptableSeed type;
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    [SerializeField] public List<InventorySlot> slots = new List<InventorySlot>();
    public void AddItem(ScriptableSeed seed) 
    {
        if (ItemInInventory(seed)) 
        {
            InventorySlot slot = slots.Find(s => s.type.name == seed.name);
            slot.quantity += 1;
        } else 
        {
            slots.Add(new InventorySlot(seed));
        }
    }

    public bool ItemInInventory(ScriptableSeed seed) 
    {
        foreach (InventorySlot slot in slots) 
        {
            if (slot.type.name == seed.name) return true;
        }
        return false;
    }
}
