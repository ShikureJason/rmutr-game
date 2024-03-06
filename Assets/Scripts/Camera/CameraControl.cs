using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    [SerializeField] private CinemachineFreeLook _freeLookVCam;
    [SerializeField][Range(.1f, 5f)] private float _speedMultiplier = 1f;

    [Header("Event Listenner")]
    [SerializeField] private VoidEvent _playerHasSpawnEventListenner = default;

    private void OnEnable()
    {
        _inputReader.MoveCameraEvent += onCameraRotate;
        _inputReader.ZoomCameraEvent += onCameraRadius;
        _playerHasSpawnEventListenner.OnEventRaised += setupTranformPlayer;
    }
    private void OnDisable()
    {
        _inputReader.MoveCameraEvent -= onCameraRotate;
        _playerHasSpawnEventListenner.OnEventRaised -= setupTranformPlayer;
    }

    private void setupTranformPlayer()
    {
        if (!_freeLookVCam.Follow || !_freeLookVCam.LookAt)
        {
            _freeLookVCam.Follow = GameObject.FindWithTag("Player").transform;
            _freeLookVCam.LookAt = GameObject.FindWithTag("Player").transform;
        }
    }

    private void onCameraRotate(Vector2 cameraMovement)
    {
        _freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * Time.deltaTime * _speedMultiplier;
        _freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * Time.deltaTime * _speedMultiplier;
    }

    private void onCameraRadius(Vector2 cameraRadius)
    {
        if ( cameraRadius.y == 120 && _freeLookVCam.m_Orbits[0].m_Radius > 3)
        {
            _freeLookVCam.m_Orbits[0].m_Radius -= 1;
            _freeLookVCam.m_Orbits[1].m_Radius -= 1;
            _freeLookVCam.m_Orbits[2].m_Radius -= 1;
        }
        else if ( cameraRadius.y == -120)
        {
            _freeLookVCam.m_Orbits[0].m_Radius += 1;
            _freeLookVCam.m_Orbits[1].m_Radius += 1;
            _freeLookVCam.m_Orbits[2].m_Radius += 1;
        }
    }

}
