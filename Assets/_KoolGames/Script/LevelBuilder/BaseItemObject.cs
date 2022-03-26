using System;
using Sirenix.OdinInspector;
using UnityEngine;
using static KoolGames.Enums;

namespace KoolGames
{
    public class BaseItemObject : MonoBehaviour
    {
        public ItensDraw itemDraw;
        [ShowInInspector][SerializeField] private MapItensData _mapItemData;

        public void Initialize(ItensDraw itemDraw, Vector2 gridPosition, Enums.MapItem mapItem = Enums.MapItem.Empty)
        {
            this.itemDraw = itemDraw;
            _mapItemData.gridPosition = gridPosition;
            _mapItemData.mapItem = mapItem;
        }

        public void SetMapItem(MapItem newMapItem)
        {
            _mapItemData.mapItem = newMapItem;
        }
        
        public MapItensData GetMapObjectData()
        {
            return _mapItemData;
        }

        [Serializable]
    public struct MapItensData
    {
        [SerializeField] public Vector2 gridPosition;
        [SerializeField] public MapItem mapItem;
    }
    }
}
