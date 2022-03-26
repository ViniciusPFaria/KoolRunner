using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KoolGames.Enums;

namespace KoolGames
{
    public class SelectionMapDrawItem : MonoBehaviour
    {
        private MapItem _currentItem;
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

            BaseItemObject basItemObject = hitInfo.transform.GetComponent<BaseItemObject>();
            if (!basItemObject)
                return;

            print("click on " + basItemObject.name);
            SetObjectColor(basItemObject);
            basItemObject.SetMapItem(_currentItem);
        }

        private void SetObjectColor(BaseItemObject baseMapObject)
        {
            switch (_currentItem)
            {
                case MapItem.Obstacle:
                    baseMapObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    break;
                case MapItem.Coin:
                    baseMapObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    break;
                case MapItem.Empty:
                    break;
            }
        }

        public void SetCurrentItem(MapItem mapItem)
        {
            _currentItem = mapItem;
        }
    }
}
