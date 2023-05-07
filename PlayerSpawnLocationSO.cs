using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSpawnLocationSO",
    menuName = "ScriptableObjects/PlayerSpawnLocationSO")]

public class PlayerSpawnLocationSO : ScriptableObject,
    ISerializationCallbackReceiver
{
    [SerializeField]
    Vector2 _defaultSpawnLocation;

    //[SerializeField]
    Vector2 _initialSpawnLocation;

    [SerializeField]
    Vector2 _defaultPlayerDirection;

    //[SerializeField]
    Vector2 _playerDirection;


    // Get animator velocity from EnterExit script.
    public Vector2 GetPlayerDirection(Vector2 playerDirection)
    {
        _playerDirection = playerDirection;
        return _playerDirection;
    }

    // Pass stored animator velocity into PlayerController Start().
    public Vector2 GetNewPlayerDirection()
    {
        return _playerDirection;
    }


    // Get Player position from EnterExit script.
    public Vector2 GetInitialPlayerPosition(Vector2 setSpawnLocation)
    {
        _initialSpawnLocation = setSpawnLocation;
        return _initialSpawnLocation;
    }

    //  Pass stored Player position in PlayerController script.
    public Vector2 GetNewPlayerPosition()
    {
        return _initialSpawnLocation;
    }

    // ISerializationCallbackReceiver methods...
    public void OnBeforeSerialize()
    {
        //Debug.Log("OnBeforeSerialize not implemented.");
    }

    // Reset spawn location and default direction Player faces
    public void OnAfterDeserialize()
    {
        _initialSpawnLocation = _defaultSpawnLocation;
        _playerDirection = _defaultPlayerDirection;
    }
}
