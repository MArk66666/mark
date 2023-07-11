using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    public override void TriggerItemBuffs(Entity entity)
    {
        IHealable healableEntity = entity.GetComponent<IHealable>();

        if (healableEntity != null)
        {
            int healAmount = currentItemStats.Health;
            healableEntity.Heal(healAmount);
        }
    }
}