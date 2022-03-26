using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KoolGames.BaseItemObject;

namespace KoolGames
{
    public class GenerateItens : MonoBehaviour
    {
        [SerializeField] private LevelDataItens _itensData;
        [SerializeField] private GameObject _forwardFloorPrefab;
        [SerializeField] private GameObject _rightFloorPrefab;
        [SerializeField] private Vector3 _startPosition;

        void Awake()
        {
            GenerateLevelMap();
        }

        public float camYOffset = 0.0f;

        private void GenerateLevelMap()
        {
            foreach (MapItensData mapItensData in _itensData.GetLevelData())
            {
                if (mapItensData.mapItem == Enums.MapItem.Empty)
                    continue;

                GameObject floorPrefab = null;
                floorPrefab = GetCorrectItemPrefab(mapItensData);
                
                if(floorPrefab == null)
                    continue;

                Instantiate(floorPrefab, new Vector3(mapItensData.gridPosition.x * 1/3, 0, mapItensData.gridPosition.y * 1/3), Quaternion.identity, transform);
            }
        }

        private GameObject GetCorrectItemPrefab(MapItensData mapItemData)
        {
            GameObject itemPrefab = null;

            if(mapItemData.mapItem == Enums.MapItem.Coin)
            {
                itemPrefab = _forwardFloorPrefab;
            }
            
            if(mapItemData.mapItem == Enums.MapItem.Obstacle)
            {
                itemPrefab = _rightFloorPrefab;
            }

            return itemPrefab;
        }
    }
}
