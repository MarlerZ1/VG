using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHp : Health
{
    [SerializeField] private int _restorePlayerHp;
    [SerializeField] private GameObject _destroyExplosionRef;
    [SerializeField] private Vector3 _offset;
    /*    [SerializeField] private float _stunTime;
        private bool _isStunned = false;*/
    /*    private bool _isHitStunned = false;

        public bool IsHitStunned
        {
            get
            {
                return _isHitStunned;
            }
        }*/

/*    private void Start()
    {
        base.Start();
   
    }*/

    public int RestorePlayerHp
    {
        get
        {
            return _restorePlayerHp;
        }
        private set { }
    }

    override public void TakeHit(int damage)
    {
        base.TakeHit(damage);
     /*   _hpBar.SetHealth(_currentHp, _maxHp);*/
        /*
                StartCoroutine(IEHitStun());*/

        if (!_isAlive)
        {
            Vector3 position = transform.position + _offset;
            Instantiate(_destroyExplosionRef, transform.position + _offset, Quaternion.identity);
            Death();
        }
    }

    public void Finished()
    {
        TakeHit(_currentHp);
    }

/*    private IEnumerator IEHitStun()
    {
        _isHitStunned = true;
        yield return new WaitForSeconds(0.2f);
        _isHitStunned = false;
    }*/
}
