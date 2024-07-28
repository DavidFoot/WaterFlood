using log4net.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerateLevel.Runtime
{
    public class EmptyTile : Tile
    {

        #region Publics
        float m_checkCardinalPointDelay = 0.01f;
        #endregion

        #region Unity API

        private void Start()
        { 
            base.Initialize();
        }
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
                            ReplaceTileWith(m_onStateChangeSwitchTo);
                        }
                    }
                }
                _currentTimer = 0;
            }
            _currentTimer += Time.fixedDeltaTime;
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0.5f, 0.5f), m_colliderRadiusToCheck);
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
