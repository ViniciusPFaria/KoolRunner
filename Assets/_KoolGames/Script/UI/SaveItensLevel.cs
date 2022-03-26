using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KoolGames.BaseItemObject;

namespace KoolGames
{
    public class SaveItensLevel : MonoBehaviour
    {
        [SerializeField] private ItensDraw _itensDraw;
        [SerializeField] private LevelDataItens _levelDataItens;


        public void Save(){
            List<BaseItemObject> baseMapObjects = _itensDraw.GetMapObjectsList();
            List<MapItensData> mapObjectsData = new List<MapItensData>();
            
            foreach (BaseItemObject baseMapObject in baseMapObjects)
            {
                MapItensData mapObjectData = new MapItensData();
                mapObjectData = baseMapObject.GetMapObjectData();
                mapObjectsData.Add(mapObjectData);
            }

            _levelDataItens.SetLevelData(mapObjectsData);
        }
    }
}
