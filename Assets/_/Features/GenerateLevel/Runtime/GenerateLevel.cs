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
            
            _gridTiles = new List<Tile>();
            m_maxLevel = _allLevels.Count;
        }
        #endregion

        #region Main methods

        public List<Tile> LoadLevelFrom(int _level) 
        {
            
            _gridTiles.Clear();
            foreach ( Transform _child in transform)
            {
                Destroy( _child.gameObject );
            }

            if (_level >= 0 && _level < m_maxLevel) { 
                _currentLevel = _allLevels[_level];
                _gridSize = _currentLevel.m_levelSize.x * _currentLevel.m_levelSize.y;
                m_maxLife = _currentLevel.m_tryLife;
                for (int i = 0 ; i < _gridSize; i++)
                {
                    Vector3 pos = GetPositionFromIndex(i);
                    ushort _index = (ushort)_currentLevel.m_levelDesign[i];
                    GameObject gridCell = Tile.IntantiateNewTile(_tilesRepository[_index], transform, pos, _currentLevel.m_interractableTiles);
                    _gridTiles.Add(gridCell.GetComponent<Tile>());
                }
            }
            m_levelScore = GetMaxScoreLevel();
            return _gridTiles;
        }

        private Vector3 GetPositionFromIndex(int i)
        {
            int y = i / _currentLevel.m_levelSize.x;
            int x = i - y * _currentLevel.m_levelSize.x;
            if (i % _currentLevel.m_levelSize.x == 0) x = 0;
            return new Vector3(x, y,0);
        }
        private int GetMaxScoreLevel()
        {
            m_levelScore = 0;
            foreach ( Tile gridTile  in _gridTiles) 
            {
                if(gridTile.m_score > 0) m_levelScore += gridTile.m_score;
            }
            return m_levelScore;
        }

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        [SerializeField] List<Level> _allLevels;
        [SerializeField] GameObject[] _tilesRepository;
        private List<Tile> _gridTiles;
        private int _gridSize;
        Level _currentLevel;
        #endregion
    }

}
