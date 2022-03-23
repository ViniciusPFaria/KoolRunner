using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KoolGames
{
    [CreateAssetMenu(fileName = "Level", menuName = "KoolGames/Level", order = 1)]
    public class LevelData : ScriptableObject
    {
        [ShowInInspector][SerializeField] private List<MapObjectData> _levelMapObjectsList = new List<MapObjectData>();    

        //set level data
        public void SetLevelData(List<MapObjectData> levelMapObjectsList)
        {
            this._levelMapObjectsList = levelMapObjectsList;
        }

        public List<MapObjectData> GetLevelData()
        {
            return _levelMapObjectsList;
        }
    }
}
