using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NextLevel : MonoBehaviour
{
    #region Type Definitions
    #endregion

    #region Events
    #endregion

    #region Constants

    private readonly float NEXT_POSITION_Y = -4.5f;
    
    #endregion

    #region Serialized Fields

    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private GameObject _nextLevel;

    [SerializeField] private Character _character;

    #endregion

    #region Standard Attributes

    #endregion

    #region Consultors and Modifiers

    #endregion

    #region API Methods

    #endregion

    #region Unity Lifecycle

    #endregion

    #region Unity Callback

    #endregion

    #region Other methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoodBoyCharacter"))
        {
            _nextLevel.SetActive(true);
            _currentLevel.SetActive(false);
            _character.transform.localPosition = new Vector3(_character.transform.localPosition.x, NEXT_POSITION_Y, _character.transform.localPosition.z);
            _character.ResetBools();
        }
    }

    #endregion
}