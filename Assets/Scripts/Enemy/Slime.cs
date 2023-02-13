using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(SimpleMove))]
[RequireComponent(typeof(EnemyHp))]
public class Slime : EnemyBase
{
    [SerializeField] private Animator _slimeAnimator;

  /*  private IEnumerator _ieLostPlayer;*/

    private SimpleMove _simpleMove;
    private Patrol _patrol;
    private SpriteRenderer _sr;
    
    private bool _canAttack = true;
    private bool _seePlayer = false;
    private bool _isRestring = false;

    private float _restringTime = 3f;
    private float _pursuitTime = 10f;

    private void Start()
    {
        base.Start();
        _simpleMove = GetComponent<SimpleMove>();
        _sr = GetComponent<SpriteRenderer>();
        _patrol = GetComponent<Patrol>();
     /*   _ieLostPlayer = IELostPlayer();*/
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


        if (_enemyHp.IsAlive && !_enemyHp.IsHitStunned && !_isRestring)
        {
            _slimeAnimator.SetBool("isMove", true);

            if (_seePlayer)
            {
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
                if (!_patrol.PatrolArea(_speed))
                {
                    _slimeAnimator.SetBool("isMove", false);
                    StartCoroutine(IERest());
                }
                else if (_patrol.Direction.x > 0)
                {
                    _sr.flipX = true;
                }
                else
                {
                    _sr.flipX = false;
                }
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
            if (_canAttack)
                StartCoroutine(IEAttack());
        }
    }

    private IEnumerator IERest()
    {
        _isRestring = true;
        yield return new WaitForSeconds(_restringTime);
        _isRestring = false;
    }

    private IEnumerator IEAttack()
    {
        _canAttack = false;
        _playerHp.TakeHit(_attackDamageBase);

        yield return new WaitForSeconds(_attackCooldownBase);
        _canAttack = true;
    }

    private IEnumerator IELostPlayer()
    {
        print("IELostPlayer");
        yield return new WaitForSeconds(_pursuitTime);
        _seePlayer = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
/*           StopCoroutine(IELostPlayer());*/

            _isRestring = false;
            _seePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           StartCoroutine(IELostPlayer());

        }
    }
}
