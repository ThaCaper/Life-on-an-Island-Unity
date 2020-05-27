using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlots : ScriptableObject
{
    public ItemObject item;
    public int amount;
    public int id;

    public InventorySlots(ItemObject _item, int _amount, int _id)
    {
        item = _item;
        amount = _amount;
        id = _id;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
