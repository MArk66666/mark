using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DamageableCollider : MonoBehaviour
{
    [Header("Damage parametrs")]
    [SerializeField, Range(.1f, 1f)] private float _rateDamage = 0.5f;
    [SerializeField] private int _damage = 1;

    private Coroutine _dealingDamageCoroutine;
    private IDamageable _damageableEntity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_damageableEntity == null)
        {
            _damageableEntity = collision.gameObject.GetComponent<IDamageable>();
            return;
        }

        if (_dealingDamageCoroutine == null)
        {
            _dealingDamageCoroutine = StartCoroutine(DealingDamage());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _damageableEntity = null;

        if (_dealingDamageCoroutine != null)
        {
            StopCoroutine(_dealingDamageCoroutine);
            _dealingDamageCoroutine = null;
        }
    }
    private IEnumerator DealingDamage()
    {
        while (true)
        {
            _damageableEntity.TakeDamage(_damage);
            yield return new WaitForSeconds(_rateDamage);
        }
    }
    private void OnEnable()
    {
        _dealingDamageCoroutine = null;
    }
    private void OnDisable()
    {
        if (_dealingDamageCoroutine != null)
            StopCoroutine(_dealingDamageCoroutine);
    }
}