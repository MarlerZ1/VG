using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBase : MonoBehaviour
{
    protected EnemyHp _enemyHp;
    protected PlayerHP _playerHp;


    [SerializeField] protected int _speed;
    [SerializeField] protected int _attackDamageBase;
    [SerializeField] protected float _attackCooldownBase;

    public void Start()
    {
        _enemyHp = GetComponent<EnemyHp>();
        _playerHp = PlayerSingleton.Player.GetComponent<PlayerHP>();
    }

    public void Finished()
    {
        if (_enemyHp.IsAlive && _enemyHp.CanFinished)
        {
            _playerHp.Heal(_enemyHp.RestorePlayerHp);
            _enemyHp.Finished();
        }
    }
}
