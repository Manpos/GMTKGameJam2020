using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoodBoyPhysics : MonoBehaviour
{
    #region Type Definitions
    #endregion

    #region Events
    #endregion

    #region Constants
    #endregion

    #region Serialized Fields

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

    private void Start()
    {
        
    }

    private void Update()
    {
        _character.UpdateCharacter();
    }

    #endregion 

    #region Other methods
    #endregion
}