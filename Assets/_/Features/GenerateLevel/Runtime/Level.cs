using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerateLevel.Runtime
{
    [System.Serializable]
    public struct Level
    {
        public string m_levelName;
        public Vector2Int m_levelSize;
        public int m_tryLife;
        public LevelType[] m_levelDesign;
        public List<Tile> m_interractableTiles;
        public Level(int maxTry, LevelType[] level,bool canAddTile, string levelName, Vector2Int coordinate, Vector2Int levelSize, List<Tile> interractableTiles)
        {
            m_tryLife = maxTry;
            m_levelDesign = level;
            m_levelName = levelName;
            m_interractableTiles = interractableTiles;
            m_levelSize = levelSize;
            m_interractableTiles = interractableTiles;
        }
    }
    [System.Serializable]
    public enum LevelType : ushort
    {
        SAND=0,
        EMPTY,
        SEEDS,
        CROPS,
        WATER,
        STONE,
        VILLAGER,
        VILLAGERDROWN,
        ZOMBIE,
        ZOMBIEDROWN,
        BRIDGE,
        BRIDGEDROWN      
    }
}
