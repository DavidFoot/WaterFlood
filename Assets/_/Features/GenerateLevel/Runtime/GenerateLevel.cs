using System.Collections;
using System.Collections.Generic;
using Tiles.Runtime;
using UnityEngine;

namespace GenerateLevel.Runtime
{
    public class GenerateLevel : MonoBehaviour
    {
        #region Publics

        #endregion

        #region Unity API
        private void Awake()
        {
            _gridSize = _levelSize.x * _levelSize.y;
            LoadLevelFrom(0);
        }
        #endregion

        #region Main methods

        private void LoadLevelFrom(int _level) {
            Level _currentLevel = _allLevels[_level];
            for (int i = 0 ; i < _gridSize; i++)
            {
                Vector3Int pos = GetPositionFromIndex(i);
                ushort _index = (ushort)_currentLevel.m_levelDesign[i];
                GameObject gridCell = Tile.IntantiateNewTile(_tilesRepository[_index], transform, pos, _currentLevel.m_interractableTiles);
                
            }
        }

        private Vector3Int GetPositionFromIndex(int i)
        {
            int y = i / _levelSize.x;
            int x = i - y * _levelSize.x;
            if (i % _levelSize.x == 0) x = 0;
            return new Vector3Int(x, y,0);
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
