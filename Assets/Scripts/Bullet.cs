using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private int _damage;
    private PersonType _personType;
    private float _speed = 10f;
    private Rigidbody2D _rb;
    private int _lifeTime = 10;
    private Coroutine _ieDestroy = null;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ieDestroy = StartCoroutine(IEDestroy());
    }

    private void OnDestroy()
    {
        if (_ieDestroy != null)
            StopCoroutine(_ieDestroy);
    }

    public void ParametersSetting(int dagame, PersonType personType, Vector2 shotDirection)
    {
        _damage = dagame;
        _personType = personType;
        _rb.velocity = shotDirection * _speed;
    }
    private IEnumerator IEDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (layerName == "Player" || layerName == "Enemy" || layerName == "Destructible Environment")
        {
            if (layerName != _personType.ToString() || layerName == "Destructible Environment")
            {

                collision.gameObject.GetComponent<Health>().TakeHit(_damage);

                Destroy(gameObject, 0);
            }
        }
        else if (layerName != "Bullet" && layerName != "Location")
        {
            Destroy(gameObject, 0);
        }
    }

}
