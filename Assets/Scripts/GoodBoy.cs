using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoodBoy : MonoBehaviour, IInteractable
{
    #region Type Definitions
    #endregion

    #region Events
    #endregion

    #region Constants
    #endregion

    #region Serialized Fields

    [SerializeField] private Transform _mainCamera;
    [SerializeField] private Transform _originalParent;
    [SerializeField] private GameObject _goodBoy;
    [SerializeField] private Transform _playPosition;
    [SerializeField] private Transform _staticPosition;

    #endregion       

    #region Standard Attributes
    
    private bool _playing = false;
    
    #endregion 

    #region Consultors and Modifiers

    private float _maxRange = 5f;
    public float MaxRange { get => _maxRange; }
    
    #endregion 

    #region API Methods
    
    public void OnStartHover()
    {
        print("Looking at GameDoggo");
    }

    public void OnInteract()
    {
        if (!_playing)
        {
            _goodBoy.transform.SetPositionAndRotation(_playPosition.position, _playPosition.rotation);
            _goodBoy.transform.SetParent(_mainCamera);
            
            _playing = true;
        }
        else
        {
            _goodBoy.transform.SetParent(_originalParent);
            _goodBoy.transform.SetPositionAndRotation(_staticPosition.position, _staticPosition.rotation);

            _playing = false;
        }
        
    }

    public void OnEndHover()
    {
        print("Not looking at GameDoggo");
    }
    
    #endregion 

    #region Unity Lifecycle
    #endregion 

    #region Unity Callback
    #endregion 

    #region Other methods
    #endregion
}