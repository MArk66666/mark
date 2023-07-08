using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 200f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        Rotate(direction);
        _rigidbody.velocity = direction * movementSpeed * Time.deltaTime;
    }

    private void Rotate(Vector2 direction)
    {
        if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
