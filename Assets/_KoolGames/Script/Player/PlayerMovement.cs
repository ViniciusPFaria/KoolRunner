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
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _initialYPositionOffset = 0;
        [SerializeField] private Transform _raycastOriginRight;
        [SerializeField] private Transform _raycastOriginLeft;

        private Vector3 _initialPosition;

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
            Vector3 playerPosition = transform.position;

            if (!IsNextPositionOnFloor(finalMovementAditive))
                return;
         


            transform.localPosition += finalMovementAditive * transform.right;


        }

        public void RotateLeft()
        {
            transform.DORotate(new Vector3(0, -90, 0), _rotationSpeed, RotateMode.WorldAxisAdd);
        }

        public void RotateRight()
        {

            transform.DORotate(new Vector3(0, 90, 0), _rotationSpeed, RotateMode.WorldAxisAdd);
        }

        public void SetInitialPosition(Vector3 initialPosition)
        {
            _initialPosition = initialPosition;
            transform.position = initialPosition;
            transform.position += new Vector3(0, _initialYPositionOffset, 0);
        }

        //do a ray cast on the right and left side of the player to see if there is a floor
        private bool IsNextPositionOnFloor(float nextPositionX)
        {
            Vector3 nextPosition = nextPositionX * transform.right;

            Vector3 nextOriginRight = nextPosition + _raycastOriginRight.position;
            Vector3 nextOriginLeft = nextPosition + _raycastOriginLeft.position;

            bool IsFloorOnRight = false;
            bool IsFloorOnLeft = false;

            RaycastHit hit;

            if (Physics.Raycast(nextOriginRight, Vector3.down, out hit, 1.0f, LayerMask.GetMask("Floor")))
            {
                IsFloorOnRight = true;
            }
            if (Physics.Raycast(nextOriginLeft, Vector3.down, out hit, 1.0f, LayerMask.GetMask("Floor")))
            {
                IsFloorOnLeft = true;
            }

            if (IsFloorOnRight && IsFloorOnLeft)
                return true;

            return false;
        }
    }
}
