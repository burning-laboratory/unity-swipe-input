#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
    using BurningLab.SwipeDetector.Utils;
#endif
    
using UnityEngine;
using UnityEngine.Events;

namespace BurningLab.SwipeDetector
{
    [AddComponentMenu("Burning-Lab/Swipe Detector/Swipe Input")]
    public class SwipeInput : MonoBehaviour
    {
        #region Inner Types

        [System.Serializable]
        private struct InputEvents
        {
            public UnityEvent<Vector2> swipeStart;
            public UnityEvent<Vector2> swipeEnd;
            public UnityEvent swipeUp;
            public UnityEvent swipeRight;
            public UnityEvent swipeDown;
            public UnityEvent swipeLeft;
        }

        #endregion

        #region Private Fields
        
        private Vector2 _posIn;
        private Vector2 _posOut;
        
        #endregion

        #region Settings

        [Header("Settings")] 
        [Tooltip("Minimal swipe lenght.")] 
        [SerializeField] [Range(0, 1000)] private float _minSwipeDistance;
        
        [Tooltip("Pause. If the value is 'true', the component does not process swipes and does not trigger events.")]
        [SerializeField] private bool _isPaused;

        [Tooltip("Swipe input events.")]
        [SerializeField] private InputEvents _events;

        #endregion

        #region Public Events
        
        /// <summary>
        /// On swipe start event.
        /// </summary>
        public UnityEvent<Vector2> OnSwipeStart => _events.swipeStart;
        
        /// <summary>
        /// On swipe end event.
        /// </summary>
        public UnityEvent<Vector2> OnSwipeEnd => _events.swipeEnd;
        
        /// <summary>
        /// On swipe up event.
        /// </summary>
        public UnityEvent OnSwipeUp => _events.swipeUp;
        
        /// <summary>
        /// On swipe right event.
        /// </summary>
        public UnityEvent OnSwipeRight => _events.swipeRight;
        
        /// <summary>
        /// On swipe down event.
        /// </summary>
        public UnityEvent OnSwipeDown => _events.swipeDown;
        
        /// <summary>
        /// On swipe left event.
        /// </summary>
        public UnityEvent OnSwipeLeft => _events.swipeLeft;

        #endregion
        
        #region Unity Event Methods

        private void Update()
        {
            if (_isPaused) return;
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _posIn = Input.mousePosition;
                _events.swipeStart.Invoke(_posIn);
            }
            
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _posOut = Input.mousePosition;

                _events.swipeEnd.Invoke(_posOut);

                Vector2 delta = _posIn - _posOut;
                if (Mathf.Abs(delta.magnitude) < _minSwipeDistance) return;
                
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                {
                    if (delta.x < 0)
                    {
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                        UnityConsole.PrintLog("SwipeInput", "Update","Swipe right detected");   
#endif
                        _events.swipeRight.Invoke();
                    }
                    else
                    {
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                        UnityConsole.PrintLog("SwipeInput", "Update","Swipe left detected.");   
#endif
                        _events.swipeLeft.Invoke();
                    }
                }
                else
                {
                    if (delta.y < 0)
                    {
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                        UnityConsole.PrintLog("SwipeInput", "Update","Swipe up detected.");
#endif
                        _events.swipeUp.Invoke();
                    }
                    else
                    {
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                        UnityConsole.PrintLog("SwipeInput", "Update","Swipe down detected.");
#endif
                        _events.swipeDown.Invoke();
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set Pause (No recognize swipes).
        /// </summary>
        public void SetPause() => _isPaused = true;
        
        /// <summary>
        /// Unset Pause (Recognize swipes).
        /// </summary>
        public void UnsetPause() => _isPaused = false;

        #endregion
    }
}
