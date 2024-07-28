using System;
using System.Linq;
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
    [SerializeField] private float _sfxvolume = default;
    [SerializeField] private bool _isfullscreen = default;

    public int LocalIndex { get { return _localindex; } set { _localindex = value; } }
    public int ResolutionIndex { get { return _resolutionindex; } set { _resolutionindex = value; } }
    public int QualityIndex { get { return _qualityindex; } set { _qualityindex = value; } }
    public float MasterVolume { get { return _mastervolume; } set { _mastervolume = value; } }
    public float SFXVolume { get { return _sfxvolume; } set { _sfxvolume = value; } }
    public float MusicVolume { get { return _musicvolume; } set { _musicvolume = value; } }
    public bool IsFullscreen { get { return _isfullscreen;} set { _isfullscreen = value; } }

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }

    internal void Initialize()
    {
        switch(Application.systemLanguage)
        {
            case SystemLanguage.Thai:
                _localindex = 0; 
                break;
            case SystemLanguage.English:
                _localindex = 1; 
                break;
            default: 
                _localindex = 1; 
                break;
        }
        string currentResolution = Screen.width + " x " + Screen.height;
        string[] resolutions = new string[Screen.resolutions.Length];

        foreach (var resolution in Screen.resolutions.Select((value, i) => new { i, value }))
        {
            string[] parts = resolution.value.ToString().Split('@');
            string data = parts[0].Trim();
            Debug.Log(data);
            resolutions[resolution.i] = data;
        }
        Debug.Log(currentResolution);
        Debug.Log(resolutions);
        _resolutionindex = Array.IndexOf(resolutions, currentResolution) == -1 ? resolutions.Length - 1 : Array.IndexOf(resolutions, currentResolution);
        Debug.Log(Screen.resolutions.Length + "And " + _resolutionindex + "Screen " + resolutions[_resolutionindex]);
        _qualityindex = 1;
        _mastervolume = QualitySettings.GetQualityLevel();
        _sfxvolume = 1;
        _musicvolume = 1;
        _isfullscreen = true;

    }
}
