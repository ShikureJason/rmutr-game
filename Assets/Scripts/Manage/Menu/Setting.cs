using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _localizationDropdown = default;
    [SerializeField] private TMP_Dropdown _resolutionDropdown = default;
    [SerializeField] private TMP_Dropdown _qualityDropdown = default;
    [SerializeField] private Slider _masterVolumeSlider = default;
    [SerializeField] private Slider _musicVolumeSlider = default;
    [SerializeField] private Slider _soundVolumeSlider = default;
    [SerializeField] private Toggle _fullscreenToggle = default;
    [SerializeField] private Button _acceptButton = default;
    [SerializeField] private AudioMixer _audioMixer = default;

    private Resolution[] resolutions = default;


    private int currentlocalindex = 0;
    private int currentresolutionindex = 0;  
    private int currentqualityindex = 0;
    private float currentmastervolume = 0;
    private float currentmusicvolume = 0;
    private float currentsoundvolume = 0;

    private int localindex = 999;
    private int resolutionindex = 999;
    private int qualityindex = 999;
    private float mastervolume = 1;
    private float musicvolume = 1;
    private float soundvolume = 1;
    private bool isfullscreen = default;
    private bool hassavedata = false;


    private IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        var localizationoptions = new List<TMP_Dropdown.OptionData>();
        var resolutionoptions = new List<TMP_Dropdown.OptionData>();
        var qualityoptions = new List<TMP_Dropdown.OptionData>();
        resolutions = Screen.resolutions;
        Debug.Log(QualitySettings.names.Length);
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale)
                currentlocalindex = i;
            localizationoptions.Add(new TMP_Dropdown.OptionData(locale.name));
        }


        for (int i = 0; i < resolutions.Length; ++i)
        {
            if (resolutions[i].Equals(Screen.currentResolution))
                currentresolutionindex = i;
            string resolutionString = resolutions[i].width + "x" + resolutions[i].height + " : " + resolutions[i].refreshRate;
            resolutionoptions.Add(new TMP_Dropdown.OptionData(resolutionString));
        }

        for (int i = 0; i < QualitySettings.names.Length; ++i)
        {
            qualityoptions.Add(new TMP_Dropdown.OptionData(QualitySettings.names[i]));
        }

        _localizationDropdown.options = localizationoptions;
        _resolutionDropdown.options = resolutionoptions;
        _qualityDropdown.options = qualityoptions;
        isfullscreen = Screen.fullScreen;
        Debug.Log(hassavedata);

        _localizationDropdown.value = currentlocalindex;
        _resolutionDropdown.value = currentresolutionindex;
        _qualityDropdown.value = QualitySettings.GetQualityLevel();
        _fullscreenToggle.isOn = isfullscreen;
        _masterVolumeSlider.value = currentmastervolume;
        _musicVolumeSlider.value = currentmusicvolume;
        _soundVolumeSlider.value = currentsoundvolume;


        _localizationDropdown.onValueChanged.AddListener((index) =>
        {
            localindex = index;
            if (!_acceptButton.interactable)
                _acceptButton.interactable = true;
        });
        _resolutionDropdown.onValueChanged.AddListener((index) =>
        {
            resolutionindex = index;
            if (!_acceptButton.interactable)
                _acceptButton.interactable = true;
        });
        _qualityDropdown.onValueChanged.AddListener((index) =>
        {
            qualityindex = index;
            if (!_acceptButton.interactable)
                _acceptButton.interactable = true;
        });
        _fullscreenToggle.onValueChanged.AddListener((isFullscreen) =>
        {
            this.isfullscreen = isFullscreen;
            if (!_acceptButton.interactable)
                _acceptButton.interactable = true;
        });
        _masterVolumeSlider.onValueChanged.AddListener((value) =>
        {
            mastervolume = value;
            _audioMixer.SetFloat("MasterVolume", value);
            if (!_acceptButton.interactable)
                _acceptButton.interactable = true;
        });
        _musicVolumeSlider.onValueChanged.AddListener((value) =>
        {
            musicvolume = value;
            _audioMixer.SetFloat("MusicVolume", value);
            if (!_acceptButton.interactable)
                _acceptButton.interactable = true;
        });
        _soundVolumeSlider.onValueChanged.AddListener((value) =>
        {
            soundvolume = value;
            _audioMixer.SetFloat("SoundVolume", value);
            if (!_acceptButton.interactable)
                _acceptButton.interactable = true;
        });


    }

    public void SettingBack()
    {
        if (!_acceptButton.interactable)
            return;
        _qualityDropdown.value = QualitySettings.GetQualityLevel();
        _localizationDropdown.value = currentlocalindex;
        _resolutionDropdown.value = currentresolutionindex;
        _fullscreenToggle.isOn = Screen.fullScreen;
        _masterVolumeSlider.value = currentmastervolume;
        _musicVolumeSlider.value = currentmusicvolume;
        _soundVolumeSlider.value = currentsoundvolume;
    }

    public void SettingAccept()
    {
        if (!_acceptButton.interactable)
            return;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localindex];
        QualitySettings.SetQualityLevel(qualityindex);
        Screen.SetResolution(resolutions[resolutionindex].width, resolutions[resolutionindex].height, isfullscreen);
        Screen.SetResolution(resolutions[currentresolutionindex].width, resolutions[currentresolutionindex].height, isfullscreen);
        _acceptButton.interactable = false;
    }
}
