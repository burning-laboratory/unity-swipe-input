using BurningLab.SwipeDetector.Examples.Scripts.MiniGame.Data;
using BurningLab.SwipeDetector.Examples.Scripts.MiniGame.Level.Obstacles;
using BurningLab.SwipeDetector.Types;
using UnityEngine;
using UnityEngine.Events;

namespace BurningLab.SwipeDetector.Examples.Scripts.MiniGame.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Character : MonoBehaviour
    {
        private Rigidbody2D _rb;
        
        [System.Serializable]
        private struct CharacterEvents
        {
            public UnityEvent characterCompleteLevel;
            public UnityEvent characterLose;
        }

        [Header("Components")] 
        [SerializeField] private SwipeInput _swipeInput;
        
        [Header("Settings")] 
        [SerializeField] private float _movingSpeed;
        [SerializeField] private CharacterEvents _events;
        
        private void Awake()
        {
            if (_rb == null) _rb = GetComponent<Rigidbody2D>();
            
            _swipeInput.OnSwipeDetected.AddListener(OnSwipeDetected);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Obstacle obstacle))
            {
                switch (obstacle.type)
                {
                    case ObstacleType.Wall:
                        Debug.Log("{BUrning-Lab} => [Character] - (OnCollisionEnter2D) -> Character collision with wall.");
                        _rb.velocity = Vector2.zero;
                        break;
                    
                    case ObstacleType.Triangle:
                        Debug.Log("{BUrning-Lab} => [Character] - (OnCollisionEnter2D) -> Character collision with triangle.");
                        _rb.velocity = Vector2.zero;
                        _events.characterLose?.Invoke();
                        break;
                    
                    case ObstacleType.WinPoint:
                        Debug.Log("{BUrning-Lab} => [Character] - (OnCollisionEnter2D) -> Character complete level.");
                        _events.characterCompleteLevel?.Invoke();
                        break;
                }
            }
        }
        
        /// <summary>
        /// On player swipe detected event handler.
        /// </summary>
        /// <param name="direction">Swipe direction.</param>
        private void OnSwipeDetected(SwipeDirection direction)
        {
            switch (direction)
            {
                case SwipeDirection.Left:
                    _rb.AddForce(Vector2.left * _movingSpeed, ForceMode2D.Impulse);
                    break;
                
                case SwipeDirection.Right:
                    _rb.AddForce(Vector2.right * _movingSpeed, ForceMode2D.Impulse);
                    break;
            }
        }
    }
}
