using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : Health
{
    [SerializeField] private int _restorePlayerHp;
    [SerializeField] HpBarBehavior _hpBar;
    /*    [SerializeField] private float _stunTime;
        private bool _isStunned = false;*/
    private bool _isHitStunned = false;

    public bool IsHitStunned
    {
        get
        {
            return _isHitStunned;
        }
    }

    private void Start()
    {
        base.Start();
        _hpBar.SetHealth(_currentHp, _maxHp);
    }

    public int RestorePlayerHp 
    { 
        get 
        {
            return _restorePlayerHp;
        }
        private set{}
    }

    override public void TakeHit(int damage)
    {
        base.TakeHit(damage);
        _hpBar.SetHealth(_currentHp, _maxHp);

        StartCoroutine(IEHitStun());

        if (!_isAlive)
            Death();
    }

    public void Finished()
    {
        TakeHit(_currentHp);
    }
    
    private IEnumerator IEHitStun()
    {
        _isHitStunned = true;
        yield return new WaitForSeconds(0.2f);
        _isHitStunned = false;
    }
}
