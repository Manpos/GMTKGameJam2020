using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Star : MonoBehaviour
{
    #region Type Definitions
    #endregion

    #region Events
    #endregion

    #region Constants
    #endregion

    #region Serialized Fields

    [SerializeField] private RectTransform _starTransform;
    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private GameObject _credits;
    [SerializeField] private Character _character;
    [SerializeField] private RectTransform _characterPosition;

    #endregion

    #region Standard Attributes

    private float _animationSpeed = 0.05f;
    private float _heightOffset = 0.05f;
    private float _maxHeight;
    private float _initialHeight;
    private bool _goesDown = false;
    #endregion

    #region Consultors and Modifiers

    #endregion

    #region API Methods

    #endregion

    #region Unity Lifecycle

    #endregion

    #region Unity Callback

    private void Start()
    {
        _initialHeight = _starTransform.localPosition.y;
    }

    private void Update()
    {
    }

    #endregion

    #region Other methods

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoodBoyCharacter"))
        {
            _currentLevel.SetActive(false);
            _credits.SetActive(true);
            _character.transform.localPosition = _characterPosition.transform.localPosition;
        }
    }
}