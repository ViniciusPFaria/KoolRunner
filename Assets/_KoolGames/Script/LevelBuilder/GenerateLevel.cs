using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class GenerateLevel : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private GameObject floorPrefab;
        [SerializeField] private GameObject cameraPlayer;
        // Start is called before the first frame update
        void Start()
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

                if (isFirst)
                {
                    cameraPlayer.transform.position = new Vector3(mapObjectData.gridPosition.x, camYOffset, mapObjectData.gridPosition.y);
                    isFirst = false;
                }

                Instantiate(floorPrefab, new Vector3(mapObjectData.gridPosition.x, 0, mapObjectData.gridPosition.y), Quaternion.identity, transform);
            }
        }
    }
}
