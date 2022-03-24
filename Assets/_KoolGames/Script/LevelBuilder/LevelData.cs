using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace KoolGames
{
    [CreateAssetMenu(fileName = "Level", menuName = "KoolGames/Level", order = 1)]
    public class LevelData : ScriptableObject
    {
        [ShowInInspector][SerializeField] private List<MapObjectData> _levelMapObjectsList;

        //set level data
        public void SetLevelData(List<MapObjectData> levelMapObjectsList)
        {
            this._levelMapObjectsList = new List<MapObjectData>(levelMapObjectsList);
            EditorUtility.SetDirty(this);
        }

        public List<MapObjectData> GetLevelData()
        {
            return _levelMapObjectsList;
        }
    }
}
