using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    [SerializeField] private VoidEvent _onSceneReady = default;
    [SerializeField] private AudioCueEvent _playMusicOn = default;
    [SerializeField] private SceneSO _thisSceneSO = default;
    [SerializeField] private AudioConfigurationSO _audioConfig = default;

    /*[Header("Pause menu music")]
    [SerializeField] private AudioCueSO _pauseMusic = default;
    [SerializeField] private BoolEvent _onPauseOpened = default;*/

    private void OnEnable()
    {
        //_onPauseOpened.OnEventRaised += PlayPauseMusic;
        _onSceneReady.OnEventRaised += PlayMusic;
    }

    private void OnDisable()
    {
        _onSceneReady.OnEventRaised -= PlayMusic;
        //_onPauseOpened.OnEventRaised -= PlayPauseMusic;
    }

    private void PlayMusic()
    {
        Debug.Log("BG RUN SS");
        _playMusicOn.RaisePlayEvent(_thisSceneSO.BackgroundMusicTrack, _audioConfig);
        Debug.Log("BG RUN");
    }

    /*private void PlayPauseMusic(bool open)
    {
        if (open)
            _playMusicOn.RaisePlayEvent(_pauseMusic, _audioConfig);
        else
            PlayMusic();
    }*/
}
