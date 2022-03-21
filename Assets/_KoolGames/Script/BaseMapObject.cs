using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoolGames
{
    public class BaseMapObject : MonoBehaviour
    {
        public Vector2 gridPosition;
        public Enums.MapDir MapDir = Enums.MapDir.Empty;
        public MapDraw mapDraw;

        public void Initialize(MapDraw mapDraw, Vector2 gridPosition, Enums.MapDir mapDir = Enums.MapDir.Empty)
        {
            this.mapDraw = mapDraw;
            this.gridPosition = gridPosition;
            this.MapDir = mapDir;
        }

    }
}
