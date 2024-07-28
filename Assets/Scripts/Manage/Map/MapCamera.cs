using UnityEngine;

public class MapCamera : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputRader = default;
    [SerializeField] private Vector3 _offset;
    [Header("Event Emitter")]
    [SerializeField] private VoidEvent _playerHasSpawnEventListenner = default;

    private Vector3 zoom;

    private bool player = false;

    private void OnEnable()
    {
        _playerHasSpawnEventListenner.OnEventRaised += initializecamera;
        _inputRader.ZoomMinimapEvent += zoomInOutMiniMap;
    }

    private void OnDisable()
    {
        _playerHasSpawnEventListenner.OnEventRaised -= initializecamera;
        _inputRader.ZoomMinimapEvent -= zoomInOutMiniMap;
    }
    private void initializecamera()
    {
        gameObject.transform.position = GameObject.FindWithTag("Player").transform.position + _offset;
        player = true;
    }

    private void zoomInOutMiniMap(float zoom)
    {
        this.zoom.y += zoom;
        Debug.Log(this.zoom.y);
    }

    private void Update()
    {
        if (player)
        {
            gameObject.transform.position = GameObject.FindWithTag("Player").transform.position + _offset + zoom;
        }
    }
}
