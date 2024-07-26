using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GenerateLevel.Runtime;
using TMPro;

namespace GameManager.Runtime
{
    public class GameManager : MonoBehaviour
    {
        #region Publics
        public static int m_scoreToAchieve;
        #endregion

        #region Unity API

        private void Start()
        {
            _lvlGenerator.LoadLevelFrom(_currentLevelCount);
            _uiLife.text = $"Coups Restants: {_lvlGenerator.m_maxLife}";
            _uiLevelCount.text = $"Level : {_currentLevelCount+1}";
        }
        private void Update()
        {          
            if (Tile.m_nbInterraction != 0) {
                _lvlGenerator.m_maxLife -= Tile.m_nbInterraction;
                Tile.m_nbInterraction = 0;
                _uiLife.text = $"Coups Restants: {_lvlGenerator.m_maxLife}";
                _uiLevelCount.text = $"Level : {_currentLevelCount + 1}";
            }
            if (_lvlGenerator.m_maxLife == 0) YouLoose();
            if (Tile.instantDeath) YouLoose();
            Debug.Log(_lvlGenerator.m_levelScore);
        }
        #endregion


        #region Main methods

        public void YouLoose()
        {
            Debug.Log("You Loose");
            _lvlGenerator.gameObject.SetActive(false);
            _looseText.SetActive(true);          
        }
        public void RestartCurrentLevel()
        {          
            AtResetEveryLevel();
        }

        private void AtResetEveryLevel()
        {
            _lvlGenerator.gameObject.SetActive(true);
            _looseText.SetActive(false);
            _lvlGenerator.LoadLevelFrom(_currentLevelCount);
            _uiLife.text = $"Coups Restants: {_lvlGenerator.m_maxLife}";
            _uiLevelCount.text = $"Level : {_currentLevelCount + 1}";
        }

        public void NextLevel()
        {
            if (_currentLevelCount + 1 >= 0 && (_currentLevelCount + 1) < _lvlGenerator.m_maxLevel)
            {
                _currentLevelCount++;
                AtResetEveryLevel();
            }
        }
        public void PreviousLevel()
        {
            if (_currentLevelCount - 1 >= 0 && (_currentLevelCount - 1) < _lvlGenerator.m_maxLevel)
            {
                _currentLevelCount--;
                AtResetEveryLevel();
            }
        }

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        [SerializeField] GenerateLevel.Runtime.GenerateLevel _lvlGenerator;
        [SerializeField] GameObject _looseText;
        [SerializeField] GameObject _winText;

        [SerializeField] TextMeshProUGUI _uiLife ;
        [SerializeField] TextMeshProUGUI _uiLevelCount ;

        int _currentLevelCount = 0;
        
        #endregion
    }

}
