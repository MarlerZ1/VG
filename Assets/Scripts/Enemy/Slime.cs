using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SimpleMove))]
[RequireComponent(typeof(EnemyHp))]
public class Slime : EnemyBase
{
    [SerializeField] private Animator _slimeAnimator;

    private SimpleMove _simpleMove;
    private bool canAttack = true;
    private SpriteRenderer _sr;
    private void Start()
    {
        base.Start();
        _simpleMove = GetComponent<SimpleMove>();
        _sr = GetComponent<SpriteRenderer>();
    }

    
    void FixedUpdate()
    {
        if (_enemyHp.IsHitStunned)
        {
            _slimeAnimator.SetBool("isHit", true);
        }
        else
        {
            _slimeAnimator.SetBool("isHit", false);
        }

        if (!_enemyHp.IsAlive)
        {
            _slimeAnimator.SetBool("isDead", true);
        }


        if (_enemyHp.IsAlive && !_enemyHp.IsHitStunned)
        {
            _slimeAnimator.SetBool("isMove", true);
            _simpleMove.MoveToPlayer(_speed);
            if (_simpleMove.Direction.x > 0)
            {
                _sr.flipX = true;
            }
            else
            {
                _sr.flipX = false;
            }
        }
        else
        {
            _slimeAnimator.SetBool("isMove", false);
            _simpleMove.MoveToPlayer(0);
        }

        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_enemyHp.IsAlive && collision.gameObject.tag == "Player" && !_enemyHp.IsHitStunned)
        {
            if (canAttack)
                StartCoroutine(IEAttack());
        }
    }
    
    private IEnumerator IEAttack()
    {
        canAttack = false;
        _playerHp.TakeHit(_attackDamageBase);

        yield return new WaitForSeconds(_attackCooldownBase);
        canAttack = true;
    }
    
}
