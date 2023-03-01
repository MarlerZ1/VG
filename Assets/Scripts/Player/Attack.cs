using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private EnemyBase _highlightedEnemy;
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private int _shotDamage;

    private bool _isController;

    private void Awake()
    {
        // InputSystemSingleton.InputSystem = InputSystemSingleton.ISys;
        InputSystemSingleton.InputSystem.Attack.Finished.performed += context => _highlightedEnemy.Finished();
        InputSystemSingleton.InputSystem.Attack.Shot.performed += context => Shot();
    }

    private void Shot()
    {
        Vector2 shotDirection;
       
        if (!_isController)
        {
            shotDirection = (Camera.main.ScreenToWorldPoint(InputSystemSingleton.InputSystem.Attack.AttackDirection.ReadValue<Vector2>()) - new Vector3(transform.position.x, transform.position.y) - _offset);
            shotDirection = shotDirection.normalized;

            GameObject bullet = Instantiate(_bulletPref, transform.position + _offset, Quaternion.identity);
            bullet.GetComponent<Bullet>().ParametersSetting(_shotDamage, PersonType.Player, shotDirection);
        } else
        {
            shotDirection = InputSystemSingleton.InputSystem.Attack.AttackDirection.ReadValue<Vector2>();
            shotDirection = shotDirection.normalized;

            GameObject bullet = Instantiate(_bulletPref, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().ParametersSetting(_shotDamage, PersonType.Player, shotDirection);
        }
    }

    public void OnDeviceChange(PlayerInput input)
    {
        _isController = input.currentControlScheme.Equals("Controller");
    }
}
