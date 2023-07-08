using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 100;

    private int _currentHealth = 0;

    public Action<int> OnHealthChanged; 

    private void Start()
    {
        _currentHealth = health;
        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Die();
    }

    public void Die()
    {

    }
}