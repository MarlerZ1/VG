using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVisualizer : MonoBehaviour
{
    [SerializeField] private HpBarBehavior _hpBar;
    private Health _health;
    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnHealthChanged += HpBarValueChanger;
    }

    private void OnEnable()
    {
        _health.OnHealthChanged += HpBarValueChanger;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= HpBarValueChanger;
    }
    private void OnDestroy()
    {
        _health.OnHealthChanged -= HpBarValueChanger;
    }

    private void HpBarValueChanger(float damage, int currentHp, int maxHp)
    {
        _hpBar.SetHealth(currentHp, maxHp);
    }
}
