using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private bool _canDash = true;
    private bool _isDashing = false;
   

    private Rigidbody2D _rb;
    private InputSystem _inputSystem;

    [SerializeField] private float _dashingPower;
    [SerializeField] private float _dashingTime;
    [SerializeField] private float _dashingCooldown;
    [SerializeField] private int _speed;

    [SerializeField] private TrailRenderer _tr;
    [SerializeField] private Animator _playerAnimator;
    private void Awake()
    {
        _inputSystem = InputSystemSingleton.ISys;
        _inputSystem.Move.Dash.performed += context => Dash();

        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }
    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void MoveVertical()
    {
        float moveDirection = _inputSystem.Move.MoveVertical.ReadValue<float>();
        if (!_isDashing)
        {
            _playerAnimator.SetFloat("VerticalMove", moveDirection);
            _rb.velocity = new Vector2(_rb.velocity.x, moveDirection * _speed);
        }
    }

    private void MoveHorizontal()
    {
        float moveDirection = _inputSystem.Move.MoveHorizontal.ReadValue<float>();
        if (!_isDashing)
        {
            _playerAnimator.SetFloat("HorizontalMove", moveDirection);
            _rb.velocity = new Vector2(moveDirection * _speed, _rb.velocity.y);
        }
    }
    
    private void Dash()
    {
        if (_canDash)
        {
            float dashHorizontalDirection = _inputSystem.Move.MoveHorizontal.ReadValue<float>();
            float dashVerticalDirection = _inputSystem.Move.MoveVertical.ReadValue<float>();
            StartCoroutine(IEDash(dashHorizontalDirection, dashVerticalDirection));
        }
    }

    private IEnumerator IEDash(float dashHorizontalDirection, float dashVerticalDirection)
    {
        _canDash = false;
        _isDashing = true;
        _tr.emitting = true;

        _rb.velocity = new Vector2(dashHorizontalDirection * _dashingPower, dashVerticalDirection * _dashingPower);
        yield return new WaitForSeconds(_dashingTime);

        _tr.emitting = false;
        _isDashing = false;
        yield return new WaitForSeconds(_dashingCooldown);

        _canDash = true;
    }

    private void FixedUpdate()
    {
        MoveVertical();
        MoveHorizontal();
        
    }
}
