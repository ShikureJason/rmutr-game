using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class NonCharacterManageSpawn : MonoBehaviour
{
    [SerializeField] private List<ActorSpawn> _spawnList;

    private async void Start()
    {
        foreach (var spawnInfo in _spawnList)
        {
            AsyncOperationHandle<GameObject> handle = spawnInfo.actor.CharacterPrefap.InstantiateAsync(spawnInfo.targetSpawn.position, spawnInfo.targetSpawn.rotation, gameObject.transform);
            await handle.Task;
        }
    }
}
