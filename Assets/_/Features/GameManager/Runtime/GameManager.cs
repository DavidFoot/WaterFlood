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
            _allGridTiles = _lvlGenerator.LoadLevelFrom(_currentLevelCount);
            EventHandler();
            _uiLife.text = $"Coups Restants: {_lvlGenerator.m_maxLife}";
            _uiLevelCount.text = $"Level : {_currentLevelCount+1}";
        }


        #endregion


        #region Main methods

        public void YouLoose()
        {
            _lvlGenerator.gameObject.SetActive(false);
            _looseText.SetActive(true);          
        }
        public void YouWin() {
            _lvlGenerator.gameObject.SetActive(false);
            _winText.SetActive(true);
        }
        public void RestartCurrentLevel()
        {          
            ToResetAtEveryLevel();
        }

        private void ToResetAtEveryLevel()
        {
            _lvlGenerator.gameObject.SetActive(true);
            _looseText.SetActive(false);
            _winText.SetActive(false);
            _lvlGenerator.LoadLevelFrom(_currentLevelCount);
            _uiLife.text = $"Coups Restants: {_lvlGenerator.m_maxLife}";
            _uiLevelCount.text = $"Level : {_currentLevelCount + 1}";
            _currentLevelScore = 0;
            _currentLevelInterract = 0;
            EventHandler();
        }

        public void NextLevel()
        {
            if (_currentLevelCount + 1 >= 0 && (_currentLevelCount + 1) < _lvlGenerator.m_maxLevel)
            {
                _currentLevelCount++;
                ToResetAtEveryLevel();
            }
        }
        public void PreviousLevel()
        {
            if (_currentLevelCount - 1 >= 0 && (_currentLevelCount - 1) < _lvlGenerator.m_maxLevel)
            {
                _currentLevelCount--;
                ToResetAtEveryLevel();
            }
        }

        public void EventHandler() 
        {
            foreach (Tile _tile in _allGridTiles) {
                _tile.m_interractEvent.AddListener(InterractCount);
                _tile.m_scoreEvent.AddListener(AddScore);
            }
        }
        public void AddScore(int score) {
            if (score == -1) YouLoose();
            _currentLevelScore+= score;
            if (_currentLevelScore == _lvlGenerator.m_levelScore) YouWin();
        }
        public void InterractCount() {
            _currentLevelInterract++;
            _uiLife.text = $"Coups Restants: {_lvlGenerator.m_maxLife - _currentLevelInterract}";
            if (_lvlGenerator.m_maxLife == _currentLevelInterract) YouLoose();
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
        List<Tile> _allGridTiles;
        int _currentLevelCount = 0;
        int _currentLevelScore = 0;
        int _currentLevelInterract = 0;
        
        #endregion
    }

}
