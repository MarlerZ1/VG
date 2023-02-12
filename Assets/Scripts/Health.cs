using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _maxHp;
    [SerializeField] protected int _currentHp;
    [SerializeField] protected int _deathTime;
    protected bool _isAlive = true;
    protected bool _canFinished = false;

    public bool CanFinished
    {
        get
        {
            return _canFinished;
        }
    }

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
    }

    virtual public void TakeHit(int damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            _isAlive = false;
            _currentHp = 0;
        }

        if ((float) _currentHp / _maxHp <= 0.25f)
        {
            _canFinished = true;
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

    virtual public void Death(){

        Destroy(gameObject, _deathTime);
    }
}
