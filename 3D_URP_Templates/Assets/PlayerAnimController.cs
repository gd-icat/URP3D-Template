using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace sarbajit.icat
{
    public class PlayerAnimController : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnim;
        private const string _moveX = "moveX", _moveY = "moveY", _slide = "slide", _dodge = "dodge";
        [SerializeField] private float _h, _v;
        private float _move;
        public void MoveInput(InputAction.CallbackContext context)
        {
            _h = context.ReadValue<Vector2>().normalized.x;
            _v = context.ReadValue<Vector2>().normalized.y;
        }

        private void Update()
        {
            if (_v != 0)
            {
                _move = Mathf.MoveTowards(_move, 1, Time.deltaTime);
            }

            else
            {
                _move = Mathf.MoveTowards(_move, 0, 5.0f * Time.deltaTime);
            }

            Move(_move);
        }

        public void Move(float movement)
        {
            if (_playerAnim)
            {
                //1D Blend Tree needs only postive values
                _playerAnim.SetFloat(_moveY, movement);
            }
        }
    }
}
