using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class MapDraw : MonoBehaviour
    {
        [SerializeField] private Vector2 _mapSize = new Vector2(20f, 20f);
        [SerializeField] private Vector2 _unitiSize;
        [SerializeField] private GameObject mapBackgroundPrefab;
        
        private List<BaseMapObject> _mapObjectsList;

        // Start is called before the first frame update
        void Start()
        {
            CreateDrawMap();
        }

        private void CreateDrawMap()
        {
            _mapObjectsList = new List<BaseMapObject>();
            // Draw a map
            for (int x = 0; x < _mapSize.x; x++)
            {
                for (int y = 0; y < _mapSize.y; y++)
                {
                    GameObject cube = GameObject.Instantiate(mapBackgroundPrefab, transform);
                    _mapObjectsList.Add(cube.GetComponent<BaseMapObject>());

                    cube.transform.localScale = new Vector3(_unitiSize.x, _unitiSize.y, 1);

                    float mapPosX = x * _unitiSize.x;
                    float mapPosY = y * _unitiSize.y;
                    cube.transform.position = new Vector3(mapPosX, mapPosY, 0);

                    Vector2 positionInGrid = new Vector2(x, y);
                    InitializeGridObject(cube, positionInGrid);

                }
            }
        }

        private void InitializeGridObject(GameObject gridObject, Vector2 positionInGrid)
        {
            BaseMapObject baseMapObject = gridObject.GetComponent<BaseMapObject>();

            baseMapObject.Initialize(this, positionInGrid);

        }

        public List<BaseMapObject> GetMapObjectsList()
        {
            return _mapObjectsList;
        }

    }
}
