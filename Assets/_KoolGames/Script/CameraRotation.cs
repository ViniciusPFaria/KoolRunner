using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KoolGames
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 1.0f;
        // Start is called before the first frame update
        void Start()
        {
        
        }

       
       [ContextMenu("Rotate")]
        public void RotateLeft()
        {
            transform.DORotate(new Vector3(0, -90, 0), _rotationSpeed, RotateMode.WorldAxisAdd);
        }

        //turn camera right by 90 degree
        public void RotateRight()
        {
            
            transform.DORotate(new Vector3(0, 90, 0), _rotationSpeed, RotateMode.WorldAxisAdd);
        }

    }
}
