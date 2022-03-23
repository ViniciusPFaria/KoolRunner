using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class SaveLevel : MonoBehaviour
    {
        [SerializeField] private MapDraw _mapDraw;
        [SerializeField] private LevelData _levelData;


        public void Save(){
            List<BaseMapObject> baseMapObjects = _mapDraw.GetMapObjectsList();
            List<MapObjectData> mapObjectsData = new List<MapObjectData>();
            
            foreach (BaseMapObject baseMapObject in baseMapObjects)
            {
                MapObjectData mapObjectData = new MapObjectData();
                mapObjectData = baseMapObject.GetMapObjectData();
                mapObjectsData.Add(mapObjectData);
            }

            _levelData.SetLevelData(mapObjectsData);
        }
    }
}
