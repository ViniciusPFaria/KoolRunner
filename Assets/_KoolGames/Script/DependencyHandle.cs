using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class DependencyHandle : MonoBehaviour
    {
        [SerializeField] GenerateLevel _generateLevel;
        [SerializeField] PlayerMovement _playerMovement;
        [SerializeField] Transform _camera;

        // Start is called before the first frame update
        void Start()
        {
            Vector3 initialPosition = _generateLevel.GetStartPosition();

            _playerMovement.SetInitialPosition(initialPosition);
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
