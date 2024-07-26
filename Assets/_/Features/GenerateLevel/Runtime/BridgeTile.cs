using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerateLevel.Runtime
{
    public class BridgeTile : Tile
    {
        #region Publics
        public float m_checkCardinalPointDelay = 0.8f;
        #endregion

        #region Unity API

        private void Update()
        {
            if (_currentTimer > m_checkCardinalPointDelay)
            {
                m_cardinalPointCollider = CheckCardinalPoint();
                foreach (Collider2D cardinalCollider in m_cardinalPointCollider)
                {
                    foreach (Tile stateChange in m_stateChangeWith)
                    {
                        if (cardinalCollider.gameObject.GetComponent<Tile>().GetType().IsEquivalentTo(stateChange.GetType()))
                        {
                            ReplaceTileWith(m_stateChangeTo);
                        }
                    }
                }
                _currentTimer = 0;
            }
            _currentTimer += Time.deltaTime;
        }

        #endregion

        #region Main methods



        #endregion

        #region Utils

        #endregion

        #region Privates & Protected
        float _currentTimer = 0;
        #endregion
    }

}
