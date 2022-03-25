using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class GenerateLevel : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private GameObject _forwardFloorPrefab;
        [SerializeField] private GameObject _rightFloorPrefab;
        [SerializeField] private GameObject _leftFloorPrefab;
        [SerializeField] private Vector3 _startPosition;

        void Awake()
        {
            GenerateLevelMap();
        }

        bool isFirst = true;
        public float camYOffset = 0.0f;

        private void GenerateLevelMap()
        {
            foreach (MapObjectData mapObjectData in _levelData.GetLevelData())
            {
                if (mapObjectData.mapDir == Enums.MapDir.Empty)
                    continue;

                GameObject floorPrefab = null;
                floorPrefab = GetCorrectFloorPrefab(mapObjectData, floorPrefab);

                CheckForFirstBlock(mapObjectData);
                Instantiate(floorPrefab, new Vector3(mapObjectData.gridPosition.x, 0, mapObjectData.gridPosition.y), Quaternion.identity, transform);
            }
        }

        private GameObject GetCorrectFloorPrefab(MapObjectData mapObjectData, GameObject floorPrefab)
        {
            switch (mapObjectData.mapDir)
            {
                case Enums.MapDir.Forward:
                    floorPrefab = _forwardFloorPrefab;
                    break;
                case Enums.MapDir.Right:
                    floorPrefab = _rightFloorPrefab;
                    break;
                case Enums.MapDir.Left:
                    floorPrefab = _leftFloorPrefab;
                    break;
                default:
                    break;
            }

            return floorPrefab;
        }

        private void CheckForFirstBlock(MapObjectData mapObjectData)
        {
            if (isFirst)
            {
                _startPosition = new Vector3(mapObjectData.gridPosition.x, camYOffset, mapObjectData.gridPosition.y);
                isFirst = false;
            }
        }

        public Vector3 GetStartPosition()
        {
            return _startPosition;
        }
    }
}
