using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] private Player playerSetup;
    [SerializeField] private Slider healthSlider;

    private float _currentHealthValue = 100f;
    private float _targetHealthValue = 0f;

    private void Start()
    {
        playerSetup.EntityHealthController.OnHealthChanged += SetHealthTargetValue;
        healthSlider.value = _currentHealthValue;
        SetHealthTargetValue(Mathf.RoundToInt(_currentHealthValue));
    }

    private void Update()
    {
        _currentHealthValue = Mathf.MoveTowards(_currentHealthValue, _targetHealthValue, 60f * Time.deltaTime);
        healthSlider.value = _currentHealthValue;
    }

    private void OnDisable()
    {
        if (playerSetup != null)
        {
            playerSetup.EntityHealthController.OnHealthChanged -= SetHealthTargetValue;
        }
    }

    public void SetHealthTargetValue(int value)
    {
        _targetHealthValue = value;
    }
}
