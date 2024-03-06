using System;
using UnityEngine;

[Serializable]
public class ActorSpawn
{
    [SerializeField] private CharacterPrefapSO _actor;
    [SerializeField] private Transform _targetSpawn;

    public CharacterPrefapSO actor => _actor;
    public Transform targetSpawn => _targetSpawn;
}
