using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarBehavior : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Vector3 _offset;
    [SerializeField] Image _fill;
    [SerializeField] private Gradient _colorGradient;

    public void SetHealth(float health, float maxHealth)
    {
        _slider.gameObject.SetActive(health < maxHealth);
        _slider.value = health;
        _slider.maxValue = maxHealth;

        _fill.color = _colorGradient.Evaluate(health / maxHealth);
    }

    private void FixedUpdate()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
    }
}
