using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace GoToApps.SwipeInput.Editor
{
    [CustomEditor(typeof(BurningLab.SwipeDetector.SwipeInput))]
    public class SwipeInputEditor : UnityEditor.Editor
    {
        private BurningLab.SwipeDetector.SwipeInput _model;
        private SerializedProperty _minSwipeDistance;
        private SerializedProperty _isPaused;
        private SerializedProperty _events;
        private SerializedProperty _detectionMode;

        private void OnEnable()
        {
            _model = (BurningLab.SwipeDetector.SwipeInput) target;

            _minSwipeDistance = serializedObject.FindProperty("_minSwipeDistance");
            _isPaused = serializedObject.FindProperty("_isPaused");
            _events = serializedObject.FindProperty("_events");
            _detectionMode = serializedObject.FindProperty("_swipeDetectionMode");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawFields();
            serializedObject.ApplyModifiedProperties();
            if (GUI.changed) OnChanged(_model.gameObject);
        }

        private void DrawFields()
        {
            EditorGUILayout.PropertyField(_detectionMode);
            EditorGUILayout.PropertyField(_minSwipeDistance);
            EditorGUILayout.PropertyField(_isPaused);
            EditorGUILayout.PropertyField(_events);
        }
        
        private void OnChanged(GameObject obj)
        {
            if (Application.isPlaying == false)
            {
                EditorUtility.SetDirty(obj);
                EditorSceneManager.MarkSceneDirty(obj.scene);
            }
        }
    }
}