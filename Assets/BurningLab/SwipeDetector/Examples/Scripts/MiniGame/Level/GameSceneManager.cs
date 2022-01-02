using UnityEngine;
using UnityEngine.SceneManagement;

namespace BurningLab.SwipeDetector.Examples.Scripts.MiniGame.Level
{
    public class GameSceneManager : MonoBehaviour
    {
        /// <summary>
        /// Restart button down event handler.
        /// </summary>
        public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}