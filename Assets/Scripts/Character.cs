using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    #region Type Definitions

    enum PlayerState
    {
        STAND, 
        WALK,
        JUMP
    }
    #endregion

    #region Events
    #endregion

    #region Constants
    #endregion

    #region Serialized Fields

    [SerializeField] private float _jumpPower = 10f;
    [SerializeField] private float _walkSpeed = 15f;
    [SerializeField] private RectTransform _objectReference;
    
    [SerializeField] private float _gravityForce = 9.8f;
    
    [SerializeField] private AudioSource _jumpAudio;
    
    #endregion       

    #region Standard Attributes
    
    private Vector2 _oldPosition;
    private Vector2 _position;

    private Vector2 _oldSpeed;
    private Vector2 _speed;

    private bool _wasOnGround;
    private bool _onGround;

    private bool _leftWallCheck = false;
    private bool _rightWallCheck = false;

    private bool _onCeiling = false;

    private PlayerState _currentPlayerState = PlayerState.JUMP;
    
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
        _speed = _oldSpeed = Vector2.zero;
    }

    public void UpdateCharacter()
    {
        MovementPhysics();
        
        Jump();
        Walk();
        ManageApplication();
    }

    #endregion 

    #region Other methods

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _speed.y += _jumpPower;
            _onGround = false;
            _jumpAudio.Play();
        }
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.A)) _speed.x = -_walkSpeed;
        else if (Input.GetKey(KeyCode.D)) _speed.x = _walkSpeed;
        else _speed.x = 0f;
    }

    private void ManageApplication()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if(Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    
    private void MovementPhysics()
    {
        _oldPosition = _objectReference.localPosition;
        _oldSpeed = _speed;

        _wasOnGround = _onGround;

        if (_onGround) _speed.y = 0;
        else _speed.y += _gravityForce * Time.deltaTime;

        if (_onCeiling && _speed.y > 0)
        {
            _speed.y = 0;
        }

        if (_leftWallCheck && _speed.x < 0)
        {
            _speed.x = 0.5f;
        }

        if (_rightWallCheck && _speed.x > 0)
        {
            _speed.x = -0.5f;
        }
        
        Vector3 addedSpeed = new Vector3(_speed.x, _speed.y, 0);
        _objectReference.localPosition += addedSpeed * Time.deltaTime;
    }
    
    #endregion
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoodBoyFloor")) _onGround = true;

        if (other.CompareTag("GoodBoyCeiling")) _onCeiling = true;

        if (other.CompareTag("GoodBoyLeftWall")) _leftWallCheck = true;
        
        if (other.CompareTag("GoodBoyRightWall")) _rightWallCheck = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GoodBoyFloor")) _onGround = false;
        
        if (other.CompareTag("GoodBoyCeiling")) _onCeiling = false;
        
        if (other.CompareTag("GoodBoyLeftWall")) _leftWallCheck = false;
        
        if (other.CompareTag("GoodBoyRightWall")) _rightWallCheck = false;
    }

    public void ResetBools()
    {
        _onGround = false;
        
        _onCeiling = false;
        
        _leftWallCheck = false;
        
        _rightWallCheck = false;
    }
    
}