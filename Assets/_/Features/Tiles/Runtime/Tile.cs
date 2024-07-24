using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles.Runtime
{
    public class  Tile : MonoBehaviour
    {
        Vector2Int coordinate { get; set; }
        int score { get; set; }
        bool isInterractable { get; set; }

        GameObject stateChangeFrom { get; set; }
        GameObject stateChangeTo { get; set; }

        // WaterFlood
        // Get CardinalObject
        // Score Management
        // onStateChange => Scoring ?  

    }
}
