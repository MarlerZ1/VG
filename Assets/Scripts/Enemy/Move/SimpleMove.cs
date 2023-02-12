using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class SimpleMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private GameObject _player;
    private Vector2 _direction;
   
    public Vector2 Direction
    {
        get
        {
            return _direction;
        }
    }

    private void Start()
    {
        _player = PlayerSingleton.Player;
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveToPlayer(int speed)
    {
        _direction = new Vector2(_player.transform.position.x - _rb.transform.position.x,
                                    _player.transform.position.y - _rb.transform.position.y).normalized;

        _rb.velocity = _direction * speed;
    }
}
