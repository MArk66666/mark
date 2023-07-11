using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Item : MonoBehaviour
{
    public string Name;
    public Sprite Icon;

    public ItemUpgrade[] Upgrades;

    protected SpriteRenderer spriteRenderer;
    protected ItemUpgrade currentItemStats;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Initialize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = collision.GetComponent<Inventory>();

        if (inventory == null)
            return;

        inventory.AddItem(this);
        gameObject.SetActive(false);
    }

    protected virtual void Initialize()
    {
        spriteRenderer.sprite = Icon;

        if (Upgrades.Length > 0)
        {
            currentItemStats = Upgrades[0];
        }
        else
        {
            Debug.LogError("Item " + Name + " has no upgrades defined!");
        }
    }

    public abstract void TriggerItemBuffs(Entity entity);
    public void Upgrade(ItemUpgrade itemUpgrade)
    {
        currentItemStats.Health += itemUpgrade.Health;
        currentItemStats.Armor += itemUpgrade.Armor;
    }
}

[System.Serializable]
public class ItemUpgrade
{
    public int Health;
    public int Armor;
}