using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KoolGames
{
    public class StakingCubes : MonoBehaviour
    {
        [SerializeField] Transform _stackingCubesHolder;
        [SerializeField] GameObject cubePrefab;
        [SerializeField] float yHeight = 0;

        private List<GameObject> _cubes = new List<GameObject>();

        
        public void AddStack(){
            //add a cube below the last one and move player up
            GameObject newCube = Instantiate(cubePrefab, _stackingCubesHolder);
            _cubes.Add(newCube);
        }

        public void RemoveStack(){
            //remove the last cube and move player down
            GameObject lastCube = _cubes[^1];
            _cubes.Remove(lastCube);
            Destroy(lastCube);
        }
    }
}
