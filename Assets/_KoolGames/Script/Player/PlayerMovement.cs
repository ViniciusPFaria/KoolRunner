using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KoolGames
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _sideSpeed = 1.0f;
        [SerializeField] private float _fowardSpeed = 1.0f;
        [SerializeField] private float _movLimitX = 1;
        [SerializeField] private float _rotationSpeed;

        // Start is called before the first frame update
        void Start()
        {
            InputToAction.onDrag += OnDrag;
        }

        private void Update()
        {
            //allways move forward
            transform.Translate(Vector3.forward * _fowardSpeed * Time.deltaTime);

        }
        private void OnDrag(Vector2 dragDelta)
        {

            float xForce = dragDelta.x;

            float finalMovementAditive = xForce * _sideSpeed * Time.deltaTime;
            Vector3 playerLocalPosition = transform.localPosition;

            if (playerLocalPosition.x + finalMovementAditive > _movLimitX)
                return;
            if (playerLocalPosition.x + finalMovementAditive < -_movLimitX)
                return;


            transform.localPosition += new Vector3(finalMovementAditive, 0, 0);


        }

        public void RotateLeft()
        {
            transform.DORotate(new Vector3(0, -90, 0), _rotationSpeed, RotateMode.WorldAxisAdd);
        }

        public void RotateRight()
        {

            transform.DORotate(new Vector3(0, 90, 0), _rotationSpeed, RotateMode.WorldAxisAdd);
        }

    }
}
