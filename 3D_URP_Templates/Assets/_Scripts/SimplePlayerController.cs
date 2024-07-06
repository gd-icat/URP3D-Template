using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public enum MovementType
{
    scripted,
    physicsBased,
    CharacterController,
    All,
    None
}

public class SimplePlayerController : MonoBehaviour
{
    [SerializeField] private MovementType _moveType = MovementType.scripted;
    [SerializeField, Range(1, 100)] private float _moveSpeed = 1, _turnSpeed = 1, _sensitivity = 5, _jumpPower;
    [SerializeField, Space(2)] private UnityEvent _OnPlayerAimStart, _OnPlayerAimEnd;
    [SerializeField, Header("Inputs"), Space(5)] private bool _jumping  = false;
    [SerializeField] private Vector3 _move;
    [SerializeField] private Vector2 _moveInput, _aimInput;
    [SerializeField] private float _hAngle, _vAngle;
    public void MoveInput(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

	public void AimInput(InputAction.CallbackContext context)
	{
        _aimInput = context.ReadValue<Vector2>();

        if (context.started)
        {
            _OnPlayerAimStart.Invoke();
        }

        if (context.canceled)
        {
            _OnPlayerAimEnd.Invoke();
        }
	}

	public void Jump(InputAction.CallbackContext context)
	{
        if (context.ReadValue<float>() > 1)
        {
            _jumping = true;
        }

        else
        {
            _jumping = false;
        }
	}

    private void Update()
    {
        //constant polling for responsive look input
        if (_aimInput != Vector2.zero)
        {
            //break down Quaternion into vector angles
            _hAngle = _aimInput.x * _turnSpeed * Time.deltaTime;
            
            //read and modify quaternion, clamp limits
            Quaternion rotation = transform.rotation;
			rotation *= Quaternion.AngleAxis(_hAngle, Vector3.up);

            //re-assign to the actuak Rotation
            transform.rotation = rotation;
        }

        else
        {
            _hAngle = 0;
        }

        if (_jumping)
        {
            _jumpPower = 10;
        }

        else
        {
            _jumpPower = 0;
        }

        if (_moveInput != Vector2.zero)
        {
            _move = new(_move.x, _jumpPower, _moveInput.y);
            transform.Translate(_move);
        }
    }
}
