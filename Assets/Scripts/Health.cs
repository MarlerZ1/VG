using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _maxHp;
    [SerializeField] protected int _currentHp;

    virtual public void TakeHit(int damage)
    {
        _currentHp -= damage;

        if (_currentHp < 0)
        {
            _currentHp = 0;
        }
    }

    virtual public void Heal(int healHp)
    {
        _currentHp += healHp;

        if (_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
    }

    virtual public void Death(){}
}
