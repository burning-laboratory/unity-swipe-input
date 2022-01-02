using UnityEngine;

namespace BurningLab.SwipeDetector.Examples.Scripts.MiniGame.Level
{
    public class MapMover : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private float _movingSpeed;
        [SerializeField] private bool _doMove;

        private void Awake()
        {
            _doMove = false;
        }

        private void Update()
        {
            if (_doMove == false) return;

            Vector3 position = transform.position;
            transform.position = Vector3.Lerp(position, position + Vector3.down, _movingSpeed * Time.deltaTime);
        }
        
        public void StartMoving()
        {
            _doMove = true;
        }
        
        public void StopMoving()
        {
            _doMove = false;
        }
    }
}
