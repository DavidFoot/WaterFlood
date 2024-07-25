using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiles.Runtime;

namespace GameManager.Runtime
{
    public class GameManager : MonoBehaviour
    {
        #region Publics

        #endregion

        #region Unity API

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
                if(hit)
                {
                    Tile tileInterraction;
                    if (hit.collider.gameObject.TryGetComponent<Tile>(out tileInterraction)) tileInterraction.OnClic();
                }


            }
        }

        #endregion

        #region Main methods



        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        #endregion
    }

}
