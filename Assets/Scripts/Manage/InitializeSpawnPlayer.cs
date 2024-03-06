using System.Collections;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class InitializeSpawnPlayer : MonoBehaviour
{
    [SerializeField] private CharacterPrefapSO _characterSpawn;
    [SerializeField] private Transform _defaultSpawn;

    [Header("Event Emitter")]
    [SerializeField] private VoidEvent _playerHasSpawnEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private VoidEvent _initializeStartSceneHasLoaded;

    private void OnEnable()
    {
        _initializeStartSceneHasLoaded.OnEventRaised += spawnPlayer;
    }
    private void OnDisable()
    {
        _initializeStartSceneHasLoaded.OnEventRaised -= spawnPlayer;
    }

    private Transform getSpawnPosition()
    {
        return _defaultSpawn;
    }

    private void spawnPlayer()
    {
        Debug.Log(_characterSpawn.CharacterPrefap);
        Transform spawnLocation = getSpawnPosition();
        AsyncOperationHandle<GameObject> asyncLoadCharacterHandle = _characterSpawn.CharacterPrefap.InstantiateAsync(spawnLocation.position, spawnLocation.rotation);
        asyncLoadCharacterHandle.Completed += operation => _playerHasSpawnEventEmitter.RaiseEvent();
    }

}
