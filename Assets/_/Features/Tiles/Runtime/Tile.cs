using log4net.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Tiles.Runtime
{
    public class  Tile : MonoBehaviour
    {
        #region Publics

        public Vector3 m_coordinate;
        public int m_score;
        public bool m_isInterractable;
        public string m_typeName;
        public Tile m_stateChangeWith;
        public GameObject m_stateChangeTo;
        public GameObject m_interractTo;
        public Renderer m_renderer;
        private List<Tile> m_interractableByLevel;
        public Collider2D[] m_cardinalPointCollider;
        public float m_colliderRadiusToCheck = 0.5f;

        #endregion


        #region Unity API

        private void Start()
        {
            Initialize();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit)
                {
                    Tile tileInterraction;
                    if (hit.collider.gameObject.TryGetComponent<Tile>(out tileInterraction)) tileInterraction.OnClic();
                }
            }
        }
        public virtual void OnMouseOver()
        {
            if (m_isInterractable)
            {
                m_renderer.material.color = Color.green;
            }
        }
        public virtual void OnMouseExit()
        {
            if (m_isInterractable)
            {
                m_renderer.material.color = Color.white;
            }
        }

        #endregion

        #region Main Methods

        public void Initialize()
        {
            m_renderer = GetComponent<Renderer>();
        }

        public virtual void OnClic()
        {
            if (m_isInterractable)
            {
                if (m_interractTo)
                {
                    GameObject newTile = IntantiateNewTile(m_interractTo, transform.parent, m_coordinate, m_interractableByLevel);
                    Destroy(this.gameObject);
                }
            }
        }
        public void ReplaceTileWith(GameObject tileReplacement)
        {
            GameObject newTile = IntantiateNewTile(m_stateChangeTo, transform.parent, m_coordinate, m_interractableByLevel);
            Destroy(this.gameObject);
        }
        public static GameObject IntantiateNewTile(GameObject go, Transform parent, Vector3 coordinate, List<Tile> interractableObjectInLevel)
        {
            GameObject newTile = Instantiate(go, parent);
            newTile.transform.position = new Vector3(coordinate.x, coordinate.y, 0);
            newTile.name = go.name + $"{coordinate.x},{coordinate.y}";
            Tile tile = newTile.GetComponent<Tile>();
            tile.SetCoordinate(coordinate.x, coordinate.y);
            tile.m_interractableByLevel = interractableObjectInLevel;
            tile.m_typeName = go.name;
            if (tile.IsInListOfInterractable(interractableObjectInLevel)) tile.m_isInterractable = true;
            return newTile;
        }
        private bool IsInListOfInterractable(List<Tile> currentLevelInterractable)
        {
            foreach (Tile _itile in currentLevelInterractable)
            {
                if (_itile.GetType().IsEquivalentTo(this.GetType())) return true;
            }
            return false;
        }
        public void SetCoordinate(float x, float y)
        {
            m_coordinate = new Vector3(x, y, 0);
        }

        public Collider2D[] CheckCardinalPoint()
        {
            // Todo Remove Hard coded values
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll((Vector2)transform.position + new Vector2(0.5f, 0.5f), m_colliderRadiusToCheck);
            return hitColliders;
        }

        #endregion


        #region Utils

        #endregion


        #region Privates & Protected

        #endregion
    }
}
