using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace sarbajit.icat
{
    public class CrosshairHandler : MonoBehaviour
    {
        [SerializeField] private Image _defaultCH, _expandedCH;
        [SerializeField] private ColorBlock _crosshairColors;
        [SerializeField] private bool _expanded = false;

        private void Start()
        {
            SetDefault();
        }

        private void Update()
        {
            #region brute force but simple code
            //if (_defaultCH && _expandedCH)
            //{
            //    if (Input.GetKeyDown(KeyCode.I) && !_expanded)
            //    {
            //        StartCoroutine(FadeImage(true, 0.5f, _defaultCH));
            //        StartCoroutine(FadeImage(false, 0.6f, _expandedCH));
            //        _expanded = true;
            //    }

            //    else if (Input.GetKeyDown(KeyCode.O) && _expanded)
            //    {
            //        StartCoroutine(FadeImage(false, 0.5f, _defaultCH));
            //        StartCoroutine(FadeImage(true, 0.6f, _expandedCH));
            //        _expanded = false;
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// Fades the target image
        /// </summary>
        /// <param name="fade">fade in/out</param>
        /// <param name="speed">how fast the transition happens</param>
        /// <param name="targetImage">Image whose color to fade</param>
        /// <returns>null, can be changed to float</returns>
        private IEnumerator FadeImage(bool fade, float speed, Image targetImage)
        {
            float amount = 1;
            float target = 0;
            
            Color color = Color.white;
            
            if (!fade)
            {
                amount = 0;
                target = 1;
                color = targetImage.color;
            }

            while(amount != target)
            {
                amount = Mathf.MoveTowards(amount, target, speed * Time.deltaTime);
                color.a = amount;
                targetImage.color = color;
                yield return null;
            }

            //Debug.Log("Faded " + targetImage.name + " to " + fade, this);
            yield return null;
        }

        private void SetDefault()
        {
            Color fadeColor = Color.white;
            fadeColor.a = 0;
            _expandedCH.color = fadeColor;
        }

        /// <summary>
        /// Optimised Function to Aim
        /// </summary>
        /// <param name="fade">fade in the target Image ?</param>
        public void ExpandCH(bool fade)
        {
            if (_defaultCH && _expandedCH)
            {
                if (fade && !_expanded)
                {
                    StartCoroutine(FadeImage(true, 0.1f, _defaultCH));
                    StartCoroutine(FadeImage(false, 0.1f, _expandedCH));
                    _expanded = true;
                }

                else if (fade && _expanded)
                {
                    StartCoroutine(FadeImage(false, 0.1f, _defaultCH));
                    StartCoroutine(FadeImage(true, 0.1f, _expandedCH));
                    _expanded = false;
                }
            }
        }
    }
}
