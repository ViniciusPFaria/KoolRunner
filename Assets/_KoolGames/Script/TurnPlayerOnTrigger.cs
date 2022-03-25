using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class TurnPlayerOnTrigger : MonoBehaviour
    {
        [SerializeField] Enums.MapDir turnDirection;
        private void OnTriggerEnter(Collider other)
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement == null)
                return;
            
            switch (turnDirection)
            {
                case Enums.MapDir.Right:
                    playerMovement.RotateRight();
                    break;
                case Enums.MapDir.Left:
                    playerMovement.RotateLeft();
                    break;
                    default:
                    break;
            }
        }
    }
}
