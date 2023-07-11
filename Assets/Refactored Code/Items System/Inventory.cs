using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Inventory : MonoBehaviour
{
    private List<Item> _currentItems = new List<Item>();
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void UpdateInventoryTraits()
    {
        foreach (Item item in _currentItems)
        {
            item.TriggerItemBuffs(_player);
        }  
    }

    public void AddItem(Item item)
    {
        _currentItems.Add(item);
        UpdateInventoryTraits();
    }

    public void RemoveItem(Item item)
    {
        if (!_currentItems.Contains(item)) return;
        _currentItems.Remove(item);
        UpdateInventoryTraits();
    }
}