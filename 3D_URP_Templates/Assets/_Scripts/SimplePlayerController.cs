using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using sarbajit.icat;

[RequireComponent(typeof(CharacterController))]
public class SimplePlayerController : MonoBehaviour
{
    [SerializeField, Header("Required References"), Space(2)] private Transform _visual, _followTarget;
    [SerializeField, Header("Control Variables"), Space(4)] 
    private MovementType _moveType = MovementType.scripted;
    [SerializeField, Range(1, 100)] private float _moveSpeed = 1, _turnSpeed = 1, _sensitivity = 5, _jumpPower;
    [SerializeField, Space(4)] private UnityEvent _OnPlayerAimStart, _OnPlayerAimEnd;
    [SerializeField, Header("Input Values"), Space(4)] private Vector3 _move; 
    [SerializeField] private bool _jumping = false, _playerLook = false;
    [SerializeField] private Vector2 _moveInput, _lookInput;
    [SerializeField] private float _hAngle, _vAngle;
    CharacterController _playerCC;
    private void Awake()
    {
        _playerCC = GetComponent<CharacterController>();
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void LookInput(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }

    public void AimInput(InputAction.CallbackContext context)
	{
        if (context.started)
        {
            _OnPlayerAimStart.Invoke();
        }

        if (context.canceled)
        {
            _OnPlayerAimEnd.Invoke();
        }
	}

	public void JumpInput(InputAction.CallbackContext context)
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
        if (_moveType == MovementType.scripted) 
        {
            if (!_jumping)
            {
                _jumpPower = Mathf.MoveTowards(_jumpPower, 0, Time.deltaTime);
            }

            else
            {
                _jumpPower = Mathf.MoveTowards(_jumpPower, 10, Time.deltaTime);
            }

            if (_moveInput != Vector2.zero)
            {
                _move = new(_moveInput.x, _jumpPower, _moveInput.y);
                transform.Translate(_move);
            }
        }

        else if (_moveType == MovementType.CharacterController)
        {
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
                _move.x = _moveInput.x;
                _move.y = _jumpPower;
                _move.z = _moveInput.y;

                _playerCC.Move(_moveSpeed * Time.deltaTime * _move);
                
                //Character Rotation
                _visual.transform.forward = _move;
            }
        }

        //Aim3D(_playerLook);
    }

    public void Aim3D(bool enable)
    {
        if (enable)
        {
            //constant polling for responsive look input
            if (_lookInput != Vector2.zero)
            {
                //break down Quaternion into vector angles
                _hAngle = _lookInput.x * _turnSpeed * Time.deltaTime;

                //read and modify quaternion, clamp limits
                Quaternion rotation = transform.rotation;
                rotation *= Quaternion.AngleAxis(_hAngle, Vector3.up);

                //re-assign to the actuak Rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _sensitivity * Time.deltaTime);
            }

            else
            {
                _hAngle = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_moveType == MovementType.physicsBased)
        {

        }
    }
}
