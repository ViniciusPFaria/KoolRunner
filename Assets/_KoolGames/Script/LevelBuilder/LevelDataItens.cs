using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static KoolGames.BaseItemObject;

namespace KoolGames
{
    [CreateAssetMenu(fileName = "LevelItens", menuName = "KoolGames/Itens", order = 1)]
    public class LevelDataItens : ScriptableObject
    {
        [ShowInInspector][SerializeField] private List<MapItensData> _levelMapItensList;

        //set level data
        public void SetLevelData(List<MapItensData> levelMapItensList)
        {
            this._levelMapItensList = new List<MapItensData>(levelMapItensList);
            EditorUtility.SetDirty(this);
        }

        public List<MapItensData> GetLevelData()
        {
            return _levelMapItensList;
        }
    }
}
