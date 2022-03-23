using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KoolGames
{
    public class DirSetupButton : MonoBehaviour
    {
        public SelectionMapDraw selectionMapDraw;
        [SerializeField] Enums.MapDir mapDir;
        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            selectionMapDraw.SetCurrentDir(mapDir);
        }
    }
}
