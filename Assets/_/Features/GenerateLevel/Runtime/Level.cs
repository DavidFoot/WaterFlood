using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerateLevel.Runtime
{
    [System.Serializable]
    public struct Level
    {
        public int tryLife;
        public LevelType[] levelDesign;

        public Level(int _try, LevelType[] level)
        {
            tryLife = _try;
            levelDesign = level;
        }
    }
    [System.Serializable]
    public enum LevelType
    {
        EMPTY=0,
        SAND,
        CROPS,
        SEEDS,
        STONE,
        VILLAGER,
        VILLAGERDROWN,
        WATER,
        ZOMBIE,
        ZOMBIEDROWN

    }
}
