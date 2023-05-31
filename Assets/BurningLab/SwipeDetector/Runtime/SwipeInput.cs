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
            public UnityEvent<Vector2> onSwipeStart;
            public UnityEvent<Vector2> onSwipeEnd;
            public UnityEvent<SwipeDirection> onSwipeDetected;
        }

        #endregion

        #region Private Fields

        private SwipeData _swipe;
        
        #endregion

        #region Settings

        [Header("Settings")] 
        [SerializeField] private DetectionMode _swipeDetectionMode;

        [Tooltip("Enable if need detection more 1 swipe directions before user release touch.")]
        [SerializeField] private bool _detectMultipleSwipes;

        [Tooltip("Handle key keyboard arrows as swipes.")]
        [SerializeField] private bool _handleKeyboardArrowsClicks;
        
        [Tooltip("Minimal swipe lenght.")] 
        [SerializeField] [Range(0, 1000)] private float _minSwipeDistance;
        
        [Tooltip("Pause. If the value is 'true', the component does not process swipes and does not trigger events.")]
        [SerializeField] private bool _isPaused;

        [Tooltip("Swipe input events.")]
        [SerializeField] private InputEvents _events;
        
        #endregion

        #region Private Fields
        
        /// <summary>
        /// Last detected swipe direction.
        /// </summary>
        private SwipeDirection _lastDetectedSwipeDirection;

        #endregion
        
        #region Public Events
        
        /// <summary>
        /// On swipe start event.
        /// </summary>
        public UnityEvent<Vector2> OnSwipeStart => _events.onSwipeStart;
        
        /// <summary>
        /// On swipe end event.
        /// </summary>
        public UnityEvent<Vector2> OnSwipeEnd => _events.onSwipeEnd;
        
        /// <summary>
        /// On swipe detected event.
        /// </summary>
        public UnityEvent<SwipeDirection> OnSwipeDetected => _events.onSwipeDetected;

        #endregion

        #region Unity Event Methods

        private void Update()
        {
            if (_isPaused) return;

            if (_handleKeyboardArrowsClicks)
            {
                SwipeDirection swipeDirection = SwipeDirection.Default;
                
                if (Input.GetKeyDown(KeyCode.UpArrow))
                    swipeDirection = SwipeDirection.Up;

                if (Input.GetKeyDown(KeyCode.RightArrow))
                    swipeDirection = SwipeDirection.Right;

                if (Input.GetKeyDown(KeyCode.DownArrow))
                    swipeDirection = SwipeDirection.Down;

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                    swipeDirection = SwipeDirection.Left;
                
                if (swipeDirection != SwipeDirection.Default)
                {
                    OnSwipeDetected?.Invoke(swipeDirection);
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                    UnityConsole.PrintLog("SwipeInput", "Update",$"Swipe {swipeDirection} detected.");
#endif
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _swipe.positionStart = Input.mousePosition;
                _events.onSwipeStart.Invoke(_swipe.positionStart);
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (_swipe.positionStart != Vector2.zero) _swipe.positionEnd = Input.mousePosition;
                else _swipe.positionEnd = Vector2.zero;

                switch (_swipeDetectionMode)
                {
                    case DetectionMode.Completed:
                        if (Input.GetKeyUp(KeyCode.Mouse0))
                        {
                            _events.onSwipeEnd.Invoke(_swipe.positionEnd);
                            if (SwipeDetectionUtils.IsSwipeALongMinDistance(_swipe, _minSwipeDistance))
                            {
                                SwipeDirection swipeDirection = SwipeDetectionUtils.ComputeSwipeDirection(_swipe);
                                
                                if (swipeDirection == _lastDetectedSwipeDirection)
                                    return;
                                _lastDetectedSwipeDirection = swipeDirection;
                                
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                                UnityConsole.PrintLog("SwipeInput", "Update",$"Swipe {swipeDirection} detected.");
#endif
                                
                                _events.onSwipeDetected?.Invoke(swipeDirection);
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
                                _events.onSwipeEnd.Invoke(_swipe.positionEnd);
                                SwipeDirection swipeDirection = SwipeDetectionUtils.ComputeSwipeDirection(_swipe);
                                
                                if (swipeDirection == _lastDetectedSwipeDirection)
                                    return;
                                _lastDetectedSwipeDirection = swipeDirection;
                                
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                                UnityConsole.PrintLog("SwipeInput", "Update",$"Swipe {swipeDirection} detected.");
#endif
                                
                                _events.onSwipeDetected?.Invoke(swipeDirection);
                                _swipe.Reset();
                            }
                        }
                        break;
                }

                if (_detectMultipleSwipes)
                    _swipe.positionStart = Input.mousePosition;
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
        
        /// <summary>
        /// Reset last detected swipe direction.
        /// </summary>
        public void Reset()
        {
            _lastDetectedSwipeDirection = SwipeDirection.Default;
        }
        
        #endregion
    }
}
