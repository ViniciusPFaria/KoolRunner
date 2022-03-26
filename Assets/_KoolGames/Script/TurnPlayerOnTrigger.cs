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

            if (turnDirection == Enums.MapDir.Right)
                playerMovement.RotateRight();

            if (turnDirection == Enums.MapDir.Left)
                playerMovement.RotateLeft();

            gameObject.SetActive(false);
        }
    }
}
