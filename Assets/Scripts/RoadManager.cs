using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadManager : MonoBehaviour
{
    #region Type Definitions
    #endregion

    #region Events
    #endregion

    #region Constants

    private readonly float TILE_SIZE = 20f;
    public float ROAD_SPEED = 10f;
    public int _tilesPerType = 3;
    private int _tilesCounter = 0;
    
    #endregion

    #region Serialized Fields

    [SerializeField] private GameObject[] _roadTiles;

    [SerializeField] private RoadBehaviour[] _initialTiles;

    [SerializeField] private Transform _tilesParent;
    
    #endregion

    #region Standard Attributes

    private RoadBehaviour _nextRoad;

    private Queue<Transform> _instantiatedRoadTiles = new Queue<Transform>();

    private GameObject _currentRoadToSpawn;

    #endregion

    #region Consultors and Modifiers

    #endregion

    #region API Methods

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        for(int i = 0; i < _initialTiles.Length; i ++)
        {
            _instantiatedRoadTiles.Enqueue(_initialTiles[i].transform);
            _initialTiles[i].OnEnterTileEnd.AddListener(SwitchRoads);
            if (i == _initialTiles.Length - 1) _nextRoad = _initialTiles[i];
        }
        
        _currentRoadToSpawn = _roadTiles[Random.Range(0, _roadTiles.Length)];
    }

    private void Update()
    {
        MoveRoad();
    }

    #endregion

    #region Unity Callback

    #endregion

    #region Other methods

    private void SwitchRoads()
    {
        RoadBehaviour holder = _instantiatedRoadTiles.Dequeue().GetComponent<RoadBehaviour>();
        holder.OnEnterTileEnd.RemoveListener(SwitchRoads);
        Destroy(holder.gameObject);

        GameObject newRoadObject = _roadTiles[Random.Range(0, _roadTiles.Length)];
        
        if (_tilesCounter >= _tilesPerType && newRoadObject != _currentRoadToSpawn)
        {
            _currentRoadToSpawn = newRoadObject;
            _tilesCounter = 0;
        }
        
        _nextRoad = Instantiate(_currentRoadToSpawn, _nextRoad.transform.position + 
                                                     (Vector3.forward * TILE_SIZE), _nextRoad.transform.rotation, _tilesParent).GetComponent<RoadBehaviour>();

        _tilesCounter++;
        
        _instantiatedRoadTiles.Enqueue(_nextRoad.transform);
        _nextRoad.OnEnterTileEnd.AddListener(SwitchRoads);
    }

    private void MoveRoad()
    {
        foreach (var tile in _instantiatedRoadTiles)
        {
            tile.position += Vector3.back * (ROAD_SPEED * Time.deltaTime);
        }
    }
    
    #endregion
}