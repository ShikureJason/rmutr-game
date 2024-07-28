using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    [SerializeField] private VoidEvent _introHasFinishEventEmitter = default;

    private VideoPlayer video;
     
    private void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        Debug.Log("Video =" + !video.isPlaying);
        video.loopPointReached += playVideoEnd;
    }

    private void playVideoEnd(VideoPlayer player)
    {
        StartCoroutine(playvideoUntil());
    }

    private IEnumerator playvideoUntil()
    {
        Debug.Log("Video =" + !video.isPlaying);
        yield return new WaitUntil(() => !video.isPlaying);
        Debug.Log("Video End");
        _introHasFinishEventEmitter.RaiseEvent();
    }
}
