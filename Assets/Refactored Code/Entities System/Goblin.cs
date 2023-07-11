using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityMovement))]
public class Goblin : Entity
{
    private EntityMovement _entityMovement;
    private Transform _player;

    private void Awake()
    {
        _entityMovement = GetComponent<EntityMovement>();
    }

    private void Start()
    {
        _player = GameObject.FindAnyObjectByType<Player>().transform;
    }

    private void FixedUpdate()
    {
        Vector2 movementDirection = (_player.position - transform.position).normalized;
        _entityMovement.Move(movementDirection);
    }
}
