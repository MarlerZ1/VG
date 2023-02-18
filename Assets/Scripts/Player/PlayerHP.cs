using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : Health
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        base.Start();
        _slider.maxValue = _maxHp;
        _slider.value = _currentHp;
    }

    override public void TakeHit(int damage)
    {
        base.TakeHit(damage);
        _slider.value = _currentHp;
        print(_currentHp);
    }
    override public void Heal(int healHp)
    {
        base.Heal(healHp);
        _slider.value = _currentHp;
    }
}
