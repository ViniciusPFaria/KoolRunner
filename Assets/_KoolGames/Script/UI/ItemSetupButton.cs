using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KoolGames
{
    public class ItemSetupButton : MonoBehaviour
    {
        public SelectionMapDrawItem selectionMapDrawItem;
        [SerializeField] Enums.MapItem mapItem;
        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            selectionMapDrawItem.SetCurrentItem(mapItem);
        }
    }
}
