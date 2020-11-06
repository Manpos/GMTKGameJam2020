using UnityEngine;
using UnityEngine.Events;

public class RoadBehaviour : MonoBehaviour
{
    #region Type Definitions
    #endregion

    #region Events

    public UnityEvent OnEnterTileEnd = new UnityEvent();
    
    #endregion

    #region Constants
    #endregion

    #region Serialized Fields
    
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
        if(other.CompareTag("Car")) OnEnterTileEnd.Invoke();
    }

    #endregion
}