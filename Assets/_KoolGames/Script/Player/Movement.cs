using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private float _movLimitX = 1;
        // Start is called before the first frame update
        void Start()
        {
            InputToAction.onDrag += OnDrag;
        }

        private void OnDrag(Vector2 dragDelta)
        {
            
            float xForce = dragDelta.x;

            float finalMovementAditive = xForce * _speed * Time.deltaTime;
            Vector3 playerLocalPosition = transform.localPosition;

            if (playerLocalPosition.x + finalMovementAditive > _movLimitX)
                return;
            if (playerLocalPosition.x + finalMovementAditive < -_movLimitX)
                return;
    

            transform.localPosition += new Vector3(finalMovementAditive, 0, 0);


        }

    }
}
