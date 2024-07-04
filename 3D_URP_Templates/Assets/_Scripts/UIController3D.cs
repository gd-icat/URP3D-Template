using UnityEngine;

namespace sarbajit.icat
{
    public class UIController3D : MonoBehaviour
    {
        //Follow a CONSISTENT STYLE for your own code, Public first, then serialized private, then non-visible private/readonly etc.
        public static bool _isPlayerAiming;


        [SerializeField] private CanvasGroup _aimPanel;
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
            if (_aimPanel) 
            {
                _fadeSpeed = 1.0f;
            }

            else
            {
                _fadeSpeed = 0.0f;
            }
        }

        private void Start()
        {
            //Configuration, changing colors, setting values, happens on start, keep "Execution Order" Consistent across all Handlers / Controllers / Managers
        }
        void Update()
        {
            #region this can become a function by itself
            //control amount based on bool
            if (_isPlayerAiming)
            {
                _fadeAmount = Mathf.MoveTowards(_fadeAmount, 0, _fadeSpeed * Time.deltaTime);
            }

            else
            {
                _fadeAmount = Mathf.MoveTowards(_fadeAmount, 1, _fadeSpeed * Time.deltaTime);
            }

            //assign amount to property
            _aimPanel.alpha = _fadeAmount;
            #endregion
        }
    }
}
