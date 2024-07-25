using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles.Runtime
{
    public class EmptyTile : Tile
    {

        #region Publics

        #endregion

        #region Unity API

        private void Start()
        {
            base.Initialize();
            Vector2[] cardinalPoints = new Vector2[]
            {
                Vector2.up,
                Vector2.down,
                Vector2.right,
                Vector2.left,
            };
            foreach (Vector2 cardinalPoint in cardinalPoints)
            {
                Debug.Log(Physics2D.OverlapPoint((Vector2)transform.position + new Vector2(0.5f,0.5f) + cardinalPoint));
                Debug.Log((Vector2)transform.position + new Vector2(0.5f, 0.5f) + cardinalPoint);
                //RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + new Vector2(0.5f, 0.5f), cardinalPoint);
                Debug.DrawRay((Vector2)transform.position + new Vector2(0.5f, 0.5f), cardinalPoint,Color.red,200f);
                //if (hit.collider)
                //{
                //    Debug.Log(hit.collider.gameObject.name);
                //}               
            }
        }
        private void Update()
        {
            //if(_currentTimer > m_checkCardinalPointDelay)
            //{
            //    m_cardinalPointCollider = CheckCardinalPoint();
            //    foreach(Collider2D cardinalCollider in m_cardinalPointCollider)
            //    {
            //        Debug.Log(cardinalCollider.gameObject.name);
            //    }
            //    _currentTimer = 0;
                
            //}
            //_currentTimer += Time.deltaTime;
            // Check Cardinal Point
            // if (m_stateChangeWith) is in Cardinal Point
            // change Tile to m_stateChangeTo
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
