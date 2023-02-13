using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform [] _wayPoints;

    private Rigidbody2D _rb;
    private Vector2 _direction;
    Transform _currentPoint;

    public Vector2 Direction
    {
        get
        {
            return _direction;
        }
    }



    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentPoint = null;
    }

    public bool PatrolArea(int speed)
    {
        
        if (!_currentPoint)
        {
            _currentPoint = _wayPoints[Random.Range(0, _wayPoints.Length - 1)];
        }

        if (Vector2.Distance(_currentPoint.position, transform.position) > 0.5f)
        {
            MoveToPoint(_currentPoint, speed);
            return true;
        } 
        else
        {
            MoveToPoint(_currentPoint, 0);
            _currentPoint = null;
            return false;
        }
    }


    private void MoveToPoint(Transform _currentPoint, int speed)
    {
        _direction = new Vector2(_currentPoint.position.x - _rb.transform.position.x,
                                    _currentPoint.position.y - _rb.transform.position.y).normalized;

        _rb.velocity = _direction * speed;
    }


}
