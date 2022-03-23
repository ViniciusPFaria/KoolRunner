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
        public static Action<Vector2> onDrag;
        // Start is called before the first frame update
        private MainLoopInputs _inputActions;
        void Start()
        {
            _inputActions = new MainLoopInputs();
            _inputActions.Enable();

            _inputActions.BasicMap.OnClick.performed += OnClickPerformed;
            _inputActions.BasicMap.MouseDrag.performed += OnMouseMovementPerformed;
        }

        private void OnMouseMovementPerformed(CallbackContext context)
        {
            Vector2 dragDelta = context.ReadValue<Vector2>();
            onDrag?.Invoke(dragDelta);
        }

        private void OnClickPerformed(CallbackContext context)
        {
            Vector2 clickPosition = _inputActions.BasicMap.MousePosition.ReadValue<Vector2>();
            onClick?.Invoke(clickPosition);
        }

        
    }
}
