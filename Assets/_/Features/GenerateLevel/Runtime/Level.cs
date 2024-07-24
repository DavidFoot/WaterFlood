using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerateLevel.Runtime
{
    [System.Serializable]
    public struct Level
    {
        public string m_levelName;
        public int m_tryLife;
        public LevelType[] m_levelDesign;
        public bool m_canAddTile;
        public Level(int maxTry, LevelType[] level,bool canAddTile, string levelName, Vector2Int coordinate)
        {
            m_tryLife = maxTry;
            m_levelDesign = level;
            m_canAddTile = canAddTile;
            m_levelName = levelName;
        }
    }
    [System.Serializable]
    public enum LevelType
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
        ZOMBIEDROWN
    }
}
