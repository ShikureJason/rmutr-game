using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInitialize : MonoBehaviour
{
    [Header("Event Emitter")]
    [SerializeField] private VoidEvent _playerHasSpawnEventEmitter;

    private void Start()
    {
        _playerHasSpawnEventEmitter.RaiseEvent();
    }
}
