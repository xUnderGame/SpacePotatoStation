using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    public ScriptableSeed type;
    public int quantity;
}

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots;
}
