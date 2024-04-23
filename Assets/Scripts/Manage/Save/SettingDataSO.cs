using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Setting Data")]
[Serializable]
public class SettingDataSO : BaseScriptableObject
{
    [SerializeField] private int _localindex = default;
    [SerializeField] private int _resolutionindex = default;
    [SerializeField] private int _qualityindex = default;
    [SerializeField] private float _mastervolume = default;
    [SerializeField] private float _musicvolume = default;
    [SerializeField] private float _soundvolume = default;
    [SerializeField] private bool _isfullscreen = default;

    public int LocalIndex { get { return _localindex; } set { _localindex = value; } }
    public int ResolutionIndex { get { return _resolutionindex; } set { _resolutionindex = value; } }
    public int QualityIndex { get { return _qualityindex; } set { _qualityindex = value; } }
    public float MasterVolume { get { return _mastervolume; } set { _mastervolume = value; } }
    public float SoundVolume { get { return _soundvolume; } set { _soundvolume = value; } }
    public float MusicVolume { get { return _musicvolume; } set { _musicvolume = value; } }
    public bool IsFullscreen { get { return _isfullscreen;} set { _isfullscreen = value; } }
}
