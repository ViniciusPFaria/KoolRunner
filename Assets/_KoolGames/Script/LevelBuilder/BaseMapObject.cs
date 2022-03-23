using System;
using Sirenix.OdinInspector;
using UnityEngine;
using static KoolGames.Enums;

namespace KoolGames
{
    public class BaseMapObject : MonoBehaviour
    {
        public MapDraw mapDraw;
        [ShowInInspector][SerializeField] private MapObjectData _mapObjectData;

        public void Initialize(MapDraw mapDraw, Vector2 gridPosition, Enums.MapDir mapDir = Enums.MapDir.Empty)
        {
            this.mapDraw = mapDraw;
            _mapObjectData.gridPosition = gridPosition;
            _mapObjectData.mapDir = mapDir;
        }

        public void SetMapDir(MapDir newMapDir)
        {
            _mapObjectData.mapDir = newMapDir;
        }
        
        public MapObjectData GetMapObjectData()
        {
            return _mapObjectData;
        }
    }

[Serializable]
    public struct MapObjectData
    {
        [SerializeField] public Vector2 gridPosition;
        [SerializeField] public MapDir mapDir;
    }
}
