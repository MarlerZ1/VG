using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemyHp _enemyHp;
    [SerializeField] protected PlayerHP _playerHp;

    [SerializeField] protected int _speed;
    [SerializeField] protected int _attackDamage;
    [SerializeField] protected float _attackCooldown;
    protected bool canFinish = false;


    public void Finished()
    {
        _playerHp.Heal(_enemyHp.RestorePlayerHp);
        print(_enemyHp.RestorePlayerHp);
        _enemyHp.Finished();
    }
}
