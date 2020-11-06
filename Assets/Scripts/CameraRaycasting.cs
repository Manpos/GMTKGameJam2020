using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraRaycasting : MonoBehaviour
{
    #region Type Definitions
    #endregion

    #region Events
    #endregion

    #region Constants
    #endregion

    #region Serialized Fields

    [SerializeField] private float _range;
    [SerializeField] private Camera _mainCamera;

    #endregion

    #region Standard Attributes

    private IInteractable _currentTarget;
    
    #endregion

    #region Consultors and Modifiers

    #endregion

    #region API Methods

    #endregion

    #region Unity Lifecycle

    private void Update()
    {
        RaycastForInteractable();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_currentTarget != null)
            {
                _currentTarget.OnInteract();
            }
        }
    }

    #endregion

    #region Unity Callback

    #endregion

    #region Other methods

    private void RaycastForInteractable()
    {
        RaycastHit hittedItem;

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hittedItem, _range))
        {
            IInteractable interactable = hittedItem.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (hittedItem.distance <= interactable.MaxRange)
                {
                    if (interactable == _currentTarget) return;
                    else if (_currentTarget != null)
                    {
                        _currentTarget.OnEndHover();
                        _currentTarget = interactable;
                        _currentTarget.OnStartHover();
                        return;
                    }
                    else
                    {
                        _currentTarget = interactable;
                        _currentTarget.OnStartHover();
                        return;
                    }
                }
            }
        }
        
        if (_currentTarget != null)
        {
            _currentTarget.OnEndHover();
            _currentTarget = null;
        }
    }
    
    #endregion
}