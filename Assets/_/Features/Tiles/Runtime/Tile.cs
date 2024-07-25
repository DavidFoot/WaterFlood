using log4net.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Tiles.Runtime
{
    public class  Tile : MonoBehaviour
    {
        public Vector3Int m_coordinate;
        public int m_score;
        public bool m_isInterractable;
        public string m_typeName;
        public float m_checkCardinalPointDelay = 0.5f;
        public GameObject m_stateChangeWith;
        public GameObject m_stateChangeTo;
        public GameObject m_interractTo;
        public Renderer m_renderer;
        private List<Tile> m_interractableByLevel;
        public List<Collider2D> m_cardinalPointCollider;


        // WaterFlood
        // Get CardinalObject
        // Score Management
        // onStateChange => Scoring ?  
        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            m_renderer = GetComponent<Renderer>();
        }

        public  virtual void OnMouseOver()
        {
            if (m_isInterractable)
            {
                m_renderer.material.color = Color.green;
            }
        }
        public  virtual void OnMouseExit()
        {
            if (m_isInterractable)
            {
                m_renderer.material.color = Color.white;
            }
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
        public static GameObject IntantiateNewTile(GameObject go, Transform parent, Vector3Int coordinate, List<Tile> interractableObjectInLevel)
        {
            GameObject newTile = Instantiate(go, parent);
            newTile.transform.position = (Vector3)coordinate;
            newTile.name = go.name + $"{coordinate.x},{coordinate.y}";
            Tile tile = newTile.GetComponent<Tile>();
            tile.SetCoordinate(coordinate.x, coordinate.y);
            tile.m_interractableByLevel = interractableObjectInLevel;
            tile.m_typeName = go.name;
            if (tile.IsInListOfInterractable(interractableObjectInLevel)) tile.m_isInterractable = true;
            return newTile;
        }
        private bool IsInListOfInterractable( List<Tile> currentLevelInterractable)
        {

            foreach (Tile _itile in currentLevelInterractable)
            {
                if (_itile.GetType().IsEquivalentTo(this.GetType())) return true;
            }
            return false;
        }
        public void SetCoordinate(int x, int y)
        {
            m_coordinate = new Vector3Int(x,y, 0);
        }

        public List<Collider2D> CheckCardinalPoint()
        {
            Vector2[] cardinalPoints = new Vector2[]
            {
                new Vector2(1,0),
                new Vector2(-1,0),
                new Vector2(0,1),
                new Vector2(0,-1)
            };
            List<Collider2D> tileList = new List<Collider2D>();
            foreach(Vector2 points in cardinalPoints) {
                tileList.Add(Physics2D.OverlapPoint(points));
            }           
            return tileList;
        }
    }
}
