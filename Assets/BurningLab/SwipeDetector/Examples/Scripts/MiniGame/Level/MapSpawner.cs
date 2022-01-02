using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BurningLab.SwipeDetector.Examples.Scripts.MiniGame.Level
{
    public class MapSpawner : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private GameObject _endPrefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private List<GameObject> _prefabs;
        [SerializeField] private List<GameObject> _spawnedTemplates;
        [SerializeField] private int _mapLenght;
        [SerializeField] private float _templateYSize;
        
        private void Awake()
        {
            for (int i = 0; i < _mapLenght; i++)
            {
                int index = Random.Range(0, _prefabs.Count);
                GameObject prefab = _prefabs[index];
                GameObject template = Instantiate(prefab, _parent);

                if (i == 0)
                {
                    Vector3 position = template.transform.position;
                    position.y += _templateYSize;
                    template.transform.position = position;
                    _spawnedTemplates.Add(template);
                    continue;
                }

                Vector3 lastPosition = _spawnedTemplates.Last().transform.position;
                lastPosition.y += _templateYSize;
                template.transform.position = lastPosition;
                _spawnedTemplates.Add(template);
            }

            GameObject endTriggerPrefab = Instantiate(_endPrefab, _parent);
            
            Vector3 endPrefabPosition = _spawnedTemplates.Last().transform.position;
            endPrefabPosition.y += _templateYSize;
            endTriggerPrefab.transform.position = endPrefabPosition;
            _spawnedTemplates.Add(endTriggerPrefab);
            
            int rndIndex = Random.Range(0, _prefabs.Count);
            GameObject endPrefab = Instantiate(_prefabs[rndIndex], _parent);
            Vector3 endPrefabPos = _spawnedTemplates.Last().transform.position;
            endPrefabPos.y += _templateYSize;
            endPrefab.transform.position = endPrefabPos;
        }
    }
}