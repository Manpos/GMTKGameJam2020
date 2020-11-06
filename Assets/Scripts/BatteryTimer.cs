using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BatteryTimer : MonoBehaviour
{
    #region Type Definitions
    #endregion

    #region Events
    #endregion

    #region Constants

    private float SHUTDOWN_TIME = 150f;

    private float _timer;
    
    private Vector4 DEFAULT_EMISSION = new Vector4(1.506f, 0.282f, 0.282f, 1f); 

    #endregion

    #region Serialized Fields

    [SerializeField] private Material _batteryIndicator;
    [SerializeField] private GameObject[] _listOfLevels;
    [SerializeField] private GameObject _character;
    #endregion

    #region Standard Attributes

    private Color _currentEmissionColor;
    
    #endregion

    #region Consultors and Modifiers

    #endregion

    #region API Methods

    private void Start()
    {
        _batteryIndicator.EnableKeyword("_EmissionColor");
        _currentEmissionColor = DEFAULT_EMISSION;
        _batteryIndicator.SetColor("_EmissionColor", _currentEmissionColor);
        _timer = SHUTDOWN_TIME;
    }

    private void Update()
    {
        if (_timer <= 0)
        {
            foreach (var level in _listOfLevels)
            {
                level.SetActive(false);
            }
            _character.SetActive(false);
        }

        _timer -= Time.deltaTime;
        TimeColor();
        _batteryIndicator.SetColor("_EmissionColor", _currentEmissionColor);
    }

    #endregion

    #region Unity Lifecycle

    #endregion

    #region Unity Callback

    #endregion

    #region Other methods
    private float Map(float value, float a1, float a2, float b1, float b2)
    {
        return b1 + (value-a1)*(b2-b1)/(a2-a1);
    }

    private void TimeColor()
    {
        _currentEmissionColor.r = Map(_timer, 0, SHUTDOWN_TIME, 0, DEFAULT_EMISSION.x);
        _currentEmissionColor.g = Map(_timer, 0, SHUTDOWN_TIME, 0, DEFAULT_EMISSION.y);
        _currentEmissionColor.b = Map(_timer, 0, SHUTDOWN_TIME, 0, DEFAULT_EMISSION.z);
    }
    
    #endregion
}