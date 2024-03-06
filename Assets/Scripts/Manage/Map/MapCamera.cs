using UnityEngine;

public class MapCamera : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [Header("Event Emitter")]
    [SerializeField] private VoidEvent _playerHasSpawnEventListenner = default;

    private bool player = false;

    private void OnEnable()
    {
        _playerHasSpawnEventListenner.OnEventRaised += initializecamera;
    }

    private void OnDisable()
    {
        _playerHasSpawnEventListenner.OnEventRaised -= initializecamera;
    }
    private void initializecamera()
    {
        gameObject.transform.position = GameObject.FindWithTag("Player").transform.position + _offset;
        player = true;
    }

    private void Update()
    {
        if (player)
        {
            gameObject.transform.position = GameObject.FindWithTag("Player").transform.position + _offset;
        }
    }
}
