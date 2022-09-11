using UnityEngine;
using UnityEngine.Events;
using BurningLab.SwipeDetector.Utils;
using BurningLab.SwipeDetector.Types;

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

        private SwipeData _swipe;
        
        #endregion

        #region Settings

        [Header("Settings")] 
        [SerializeField] private DetectionMode _swipeDetectionMode;
        
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

        #region Private Methods

        /// <summary>
        /// Invoking swipe events for computed swipe.
        /// </summary>
        /// <param name="swipeDirection">Computes swipe direction.</param>
        private void ProcessComputedSwipe(SwipeDirection swipeDirection)
        {
            switch (swipeDirection)
            {
                case SwipeDirection.Up:
                    _events.swipeUp?.Invoke();
                    break;
                
                case SwipeDirection.Right:
                    _events.swipeRight?.Invoke();
                    break;
                
                case SwipeDirection.Down:
                    _events.swipeDown?.Invoke();
                    break;
                
                case SwipeDirection.Left:
                    _events.swipeLeft?.Invoke();
                    break;
            }
        }

        #endregion
        
        #region Unity Event Methods

        private void Update()
        {
            if (_isPaused) return;
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _swipe.positionStart = Input.mousePosition;
                _events.swipeStart.Invoke(_swipe.positionStart);
            }

            if (_swipe.positionStart != Vector2.zero) _swipe.positionEnd = Input.mousePosition;
            else _swipe.positionEnd = Vector2.zero;

            switch (_swipeDetectionMode)
            {
                case DetectionMode.Completed:
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        _events.swipeEnd.Invoke(_swipe.positionEnd);
                        if (SwipeDetectionUtils.IsSwipeALongMinDistance(_swipe, _minSwipeDistance))
                        {
                            SwipeDirection swipeDirection = SwipeDetectionUtils.ComputeSwipeDirection(_swipe);
                            ProcessComputedSwipe(swipeDirection);
                            _swipe.Reset();
                        }
                    }
                    break;
                
                case DetectionMode.Uncompleted:
                    if (_swipe.positionEnd != Vector2.zero)
                    {
                        if (Input.GetKeyUp(KeyCode.Mouse0))
                        {
                            _swipe.Reset();
                            return;
                        }

                        if (SwipeDetectionUtils.IsSwipeALongMinDistance(_swipe, _minSwipeDistance))
                        {
                            _events.swipeEnd.Invoke(_swipe.positionEnd);
                            SwipeDirection swipeDirection = SwipeDetectionUtils.ComputeSwipeDirection(_swipe);
                            ProcessComputedSwipe(swipeDirection);
                            _swipe.Reset();
                        }
                    }
                    break;
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
