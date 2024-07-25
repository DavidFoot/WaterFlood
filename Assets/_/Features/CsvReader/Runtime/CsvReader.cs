using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CsvReader.Runtime
{
    public class CsvReader : MonoBehaviour
    {
        #region Publics
        public TextAsset m_myTextFile;
        #endregion

        #region Unity API
        //private void Awake() => Initialize();



        #endregion

        #region Main methods

        private void Initialize()
        {
            string textContent = m_myTextFile.ToString();
            Debug.Log($"textContent: {m_myTextFile.ToString()}");
            string[] splittedMap = textContent.Split(',');
            foreach ( string map in splittedMap )
            {
                int intified = int.Parse(map);
                //Debug.Log($"Valeur Lue {intified}  Type: {intified.GetType()}");
            }
        }

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        #endregion
    }

}
