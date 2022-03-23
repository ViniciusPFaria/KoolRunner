using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KoolGames.Enums;

namespace KoolGames
{
    public class SelectionMapDraw : MonoBehaviour
    {
        private MapDir _currentMapDir;
        // Start is called before the first frame update
        void Start()
        {
            InputToAction.onClick += OnClick;
        }

        private void OnClick(Vector2 clickPos)
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(clickPos), out hitInfo);
            if (!hit)
                return;

            BaseMapObject baseMapObject = hitInfo.transform.GetComponent<BaseMapObject>();
            if (!baseMapObject)
                return;

            print("click on " + baseMapObject.name);
            SetObjectColor(baseMapObject);
            baseMapObject.SetMapDir(_currentMapDir);
        }

        private void SetObjectColor(BaseMapObject baseMapObject)
        {
            switch (_currentMapDir)
            {
                case MapDir.Right:
                    baseMapObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    break;
                case MapDir.Left:
                    baseMapObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    break;
                case MapDir.Strait:
                    baseMapObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                    break;
                case MapDir.Empty:
                    baseMapObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                    break;
            }
        }

        public void SetCurrentDir(MapDir mapDir)
        {
            _currentMapDir = mapDir;
        }
    }
}
