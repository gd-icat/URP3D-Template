using UnityEngine;
using UnityEngine.UI;

namespace sarbajit.icat
{
    public class UIController3D : MonoBehaviour
    {
        //Follow a CONSISTENT STYLE for your own code, Public first, then serialized private, then non-visible private/readonly etc.
        [SerializeField] private bool _playerAiming = false;
        [SerializeField] private Image _defaultCH;
        [SerializeField] private CanvasGroup _aimPanel;
        [SerializeField]
        private float _fadeAmount, _fadeSpeed;

        #region This is how to "hide" or "collapse" regions
        // Update is called once per frame
        /* multiline 
         * comment
         * to quickly comment out "blocks" of code */
        // Ctrl/Cmd + K, to bring up all options
        // then Ctrl/Cmd + C to comment, Ctrl/Cmd + U to Uncomment.
        //Can be accessed from the Menu or RMB Click as well.
        //Comment the approach, then fill in the code.
        #endregion

        private void Awake()
        {
            //Dependency check happens in awake
            //If panel is available, behaviour cannot run, must be disabled by multiplying with 0
        }

        private void Start()
        {
            /*Configuration, changing colors, setting values, happens on start.
             * Keep "Execution Order" Consistent across all Handlers / Controllers / Managers */
            if (!_aimPanel || !_defaultCH)
            {
                _fadeSpeed = 0.0f;
            }

            else
            {
                _playerAiming = false;
            }
        }
        void Update()
        {
            #region this can become a function by itself
            ////control amount based on static bool
            //if (_isPlayerAiming)
            //{
            //    _fadeAmount = Mathf.MoveTowards(_fadeAmount, 0, _fadeSpeed * Time.deltaTime);
            //}

            //else
            //{
            //    _fadeAmount = Mathf.MoveTowards(_fadeAmount, 1, _fadeSpeed * Time.deltaTime);
            //}
            #endregion
            
            //control amount based on private bool
            if (!_playerAiming)
            {
                _fadeAmount = Mathf.MoveTowards(_fadeAmount, 0, _fadeSpeed * Time.deltaTime);
            }

            else
            {
                _fadeAmount = Mathf.MoveTowards(_fadeAmount, 1, _fadeSpeed * Time.deltaTime);
            }

            //assign amount to property
            _aimPanel.alpha = _fadeAmount;

            //default CH Color lerp
            if (_defaultCH)
            {
                _defaultCH.color = Color.Lerp(Color.white, Color.clear, _fadeAmount);
            }
        }

        public void ChangeAim(bool aim)
        {
            _playerAiming = aim;
        }

        public void FlipAim()
        {
            _playerAiming = !_playerAiming;
        }
    }
}
