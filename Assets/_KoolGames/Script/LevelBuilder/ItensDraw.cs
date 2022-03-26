using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class ItensDraw : MonoBehaviour
    {
        [SerializeField] private float mapPosY;
        [SerializeField] private Vector2 _mapSize = new Vector2(20f, 20f);
        [SerializeField] private Vector2 _unitiSize;
        [SerializeField] private GameObject mapBackgroundPrefab;
        
        private List<BaseItemObject> _mapObjectsList;

        // Start is called before the first frame update
        void Start()
        {
            CreateDrawMap();
        }

        private void CreateDrawMap()
        {
            _mapObjectsList = new List<BaseItemObject>();
            // Draw a map
            for (int x = 0; x < _mapSize.x; x++)
            {
                for (int z = 0; z < _mapSize.y; z++)
                {
                    GameObject cube = GameObject.Instantiate(mapBackgroundPrefab, transform);
                    _mapObjectsList.Add(cube.GetComponent<BaseItemObject>());

                    cube.transform.localScale = new Vector3(_unitiSize.x, .1f, _unitiSize.y);

                    float mapPosX = x * _unitiSize.x;
                    float mapPosZ = z * _unitiSize.y;
                    cube.transform.position = new Vector3(mapPosX, mapPosY, mapPosZ);

                    Vector2 positionInGrid = new Vector2(x, z);
                    InitializeGridObject(cube, positionInGrid);

                }
            }
        }

        private void InitializeGridObject(GameObject gridObject, Vector2 positionInGrid)
        {
            BaseItemObject baseMapObject = gridObject.GetComponent<BaseItemObject>();

            baseMapObject.Initialize(this, positionInGrid);

        }

        public List<BaseItemObject> GetMapObjectsList()
        {
            return _mapObjectsList;
        }

    }
}
