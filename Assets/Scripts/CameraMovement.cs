using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    #region Type Definitions
    #endregion

    #region Events
    #endregion

    #region Constants
    #endregion

    #region Serialized Fields

    [SerializeField] private Transform _cameraTransform;

    #endregion

    #region Standard Attributes

    private float _mouseSensitivity = 200f;

    private float xRotation = 0f;

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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _cameraTransform.Rotate(Vector3.up * mouseX);
    }

    #endregion

    #region Other methods

    #endregion
}