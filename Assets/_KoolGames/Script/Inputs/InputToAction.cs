using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace KoolGames
{
    public class InputToAction : MonoBehaviour
    {
        public static Action<Vector2> onClick;
        // Start is called before the first frame update
        private MainLoopInputs _inputActions;
        void Start()
        {
            _inputActions = new MainLoopInputs();
            _inputActions.Enable();

            _inputActions.BasicMap.OnClick.performed += OnClickPerformed;
        }

        private void OnClickPerformed(CallbackContext context)
        {
            Vector2 clickPosition = _inputActions.BasicMap.MousePosition.ReadValue<Vector2>();
            onClick?.Invoke(clickPosition);
        }

        
    }
}
