using System.Collections;
using System.Collections.Generic;
using UnityEngine;
     
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(EntityMovement))]
[RequireComponent(typeof(EntityHealthController))]
public class Player : Entity
{
    private InputHandler _inputs;
    private EntityMovement _entityMovement;

    public EntityHealthController EntityHealthController { get; private set; }

    private void Awake()
    {
        _inputs = GetComponent<InputHandler>();
        _entityMovement = GetComponent<EntityMovement>();
        EntityHealthController = GetComponent<EntityHealthController>();
    }

    private void Update()
    {
        _inputs.TickInput();
    }

    private void FixedUpdate()
    {
        _entityMovement.Move(_inputs.moveInput.normalized);
    }
}