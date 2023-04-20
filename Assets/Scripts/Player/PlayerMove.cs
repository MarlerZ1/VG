using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private bool _canDash = true;
    private bool _isDashing = false;
   

    private Rigidbody2D _rb;

    [SerializeField] private float _dashingPower;
    [SerializeField] private float _dashingTime;
    [SerializeField] private float _dashingCooldown;
    [SerializeField] private int _speed;

    [SerializeField] private TrailRenderer _tr;
    [SerializeField] private Animator _playerAnimator;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        InputSystemSingleton.InputSystem.Move.Dash.performed += Dash;
    }

    private void OnDisable() {
        InputSystemSingleton.InputSystem.Move.Dash.performed -= Dash;
    }

    // private void OnEnable()
    // {
    //     GameStateController.Instance.OnGameStateChanged += RecheckInputAvailability;
    // }
    // private void OnDisable()
    // {
    //     GameStateController.Instance.OnGameStateChanged -= RecheckInputAvailability;
    // }

    // private void RecheckInputAvailability(GameStateController.GameState newState) {
    //     switch (newState)
    //     {
    //         case GameStateController.GameState.Normal:
    //         {
    //             InputSystemSingleton.InputSystem.Enable();
    //             break;
    //         }
    //         case GameStateController.GameState.Pause:
    //         {
    //             InputSystemSingleton.InputSystem.Disable();
    //             break;
    //         }
    //         default:
    //         {
    //             break;
    //         }
    //     }
    // }


    private void MoveVertical()
    {
        float moveDirection = InputSystemSingleton.InputSystem.Move.MoveVertical.ReadValue<float>();
        if (!_isDashing)
        {
            _playerAnimator.SetFloat("VerticalMove", moveDirection);
            _rb.velocity = new Vector2(_rb.velocity.x, moveDirection * _speed);
        }
    }

    private void MoveHorizontal()
    {
        float moveDirection = InputSystemSingleton.InputSystem.Move.MoveHorizontal.ReadValue<float>();
        if (!_isDashing)
        {
            _playerAnimator.SetFloat("HorizontalMove", moveDirection);
            _rb.velocity = new Vector2(moveDirection * _speed, _rb.velocity.y);
        }
    }
    
    private void Dash(InputAction.CallbackContext context)
    {
        if (_canDash)
        {
            float dashHorizontalDirection = InputSystemSingleton.InputSystem.Move.MoveHorizontal.ReadValue<float>();
            float dashVerticalDirection = InputSystemSingleton.InputSystem.Move.MoveVertical.ReadValue<float>();


            Debug.Log("dfgdfg");

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
