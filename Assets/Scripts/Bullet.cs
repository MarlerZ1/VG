using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private int _damage;
    PersonType _personType;
    private float _speed = 10f;
    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void ParametersSetting(int dagame, PersonType personType, Vector2 shotDirection)
    {
        _damage = dagame;
        _personType = personType;
        _rb.velocity = shotDirection * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (layerName == "Player" || layerName == "Enemy" || layerName == "Destructible Environment")
        {
            if (layerName != _personType.ToString() || layerName == "Destructible Environment")
            {
                print(_personType.ToString() + " " + LayerMask.LayerToName(collision.gameObject.layer));
                switch (layerName)
                {
                    case "Player":
                        collision.gameObject.GetComponent<PlayerHP>().TakeHit(_damage);
                        break;
                    case "Enemy":
                        collision.gameObject.GetComponent<EnemyHp>().TakeHit(_damage);
                        break;
                    case "Destructible Environment":
                        collision.gameObject.GetComponent<ObjectHp>().TakeHit(_damage);
                        break;
                }
                
                Destroy(gameObject, 0);
            }
        }
        else if (layerName != "Bullet" && layerName != "Location")
        {
            Destroy(gameObject, 0);
        }
    }
}
