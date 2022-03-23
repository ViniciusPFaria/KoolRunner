using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class rotation : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            //make this object always rotate around the y axis
            transform.Rotate(new Vector3(0, .1f, 0));

        }
    }
}
