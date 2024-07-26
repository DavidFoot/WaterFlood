using System.Collections.Generic;
using UnityEngine;

namespace GenerateLevel.Runtime
{
    public class GenerateLevel : MonoBehaviour
    {
        #region Publics
        public int m_maxLevel = 0;
        public int m_maxLife = 0;
        public int m_levelScore;
        #endregion

        #region Unity API
        private void Awake()
        {
            _gridSize = _levelSize.x * _levelSize.y;
            m_maxLevel = _allLevels.Count;
        }
        #endregion

        #region Main methods

        public void LoadLevelFrom(int _level) {
            
            foreach( Transform _child in transform)
            {
                Destroy( _child.gameObject );
            }

            if (_level >= 0 && _level < m_maxLevel) { 
                Level _currentLevel = _allLevels[_level];
                m_maxLife = _currentLevel.m_tryLife;
                for (int i = 0 ; i < _gridSize; i++)
                {
                    Vector3 pos = GetPositionFromIndex(i);
                    ushort _index = (ushort)_currentLevel.m_levelDesign[i];
                    GameObject gridCell = Tile.IntantiateNewTile(_tilesRepository[_index], transform, pos, _currentLevel.m_interractableTiles);               
                }
            }
            Tile.Reset();
            m_levelScore = Tile.GetScoreLevel();
        }

        private Vector3 GetPositionFromIndex(int i)
        {
            int y = i / _levelSize.x;
            int x = i - y * _levelSize.x;
            if (i % _levelSize.x == 0) x = 0;
            return new Vector3(x, y,0);
        }

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        [SerializeField] List<Level> _allLevels;
        [SerializeField] GameObject[] _tilesRepository;
        [SerializeField] Vector2Int _levelSize ;
        private int _gridSize;      

        #endregion
    }

}
