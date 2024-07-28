
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UIElements;

public class SettingView : UIView
{
    internal static VoidEvent CloseSetting;
    //private const String classActive = "";
    private const string dropdownLangueName = "dropdown_language";
    private const string DropdownResolutionName = "dropdown_resolution";
    private const string DropdownQualityGraphicName = "dropdown_quaility_graphic";
    private const string ToggleFullScreenName = "toggle_full_screen";
    private const string SliderMasterVolumeName = "slider_master";
    private const string SliderMusicVolumeName = "slider_music";
    private const string SliderSFXVolumeName = "slider_sfx";
    private const string ButtonBackName = "button_back";
    private const string ButtonApplyName = "button_apply";
    private const string DropdownLanguageName = "dropdown_language";

    private DropdownField dropdownLanguage;
    private DropdownField dropdownResolution;
    private DropdownField dropdownQualityGraphic;
    private Toggle toggleFullScreen;
    private Slider sliderMasterVolume;
    private Slider sliderMusicVolume;
    private Slider sliderSFXVolume;
    private Button buttonApply;
    private Button buttonBack;

    private int currentLocalindex = 0;
    private int currentResolutionIndex = 0;
    private int currentQualityIndex = 0;
    private float currentMasterVolume = 0;
    private float currentMusicVolume = 0;
    private float currentSFXVolume = 0;
    private bool isFullscreen = false;
    private bool hasChange = false;

    private SettingDataSO settingData = GameData.Instance.SettingData;
    private Resolution[] resolutions;
    private List<String> localizationoptions = new List<String>();
    private List<String> resolutionoptions = new List<String>();
    private List<String> qualityoptions = new List<String>();

    
    public SettingView(VisualElement topElement) : base(topElement)
    {
        CloseSetting = ScriptableObject.CreateInstance<VoidEvent>();
    } 

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        dropdownLanguage = m_TopElement.Q<DropdownField>(dropdownLangueName);
        dropdownResolution = m_TopElement.Q<DropdownField>(DropdownResolutionName);
        dropdownQualityGraphic = m_TopElement.Q<DropdownField>(DropdownQualityGraphicName);
        toggleFullScreen = m_TopElement.Q<Toggle>(ToggleFullScreenName);
        sliderMasterVolume = m_TopElement.Q<Slider>(SliderMasterVolumeName);
        sliderMusicVolume = m_TopElement.Q<Slider>(SliderMusicVolumeName);
        sliderSFXVolume = m_TopElement.Q<Slider>(SliderSFXVolumeName);

        buttonBack = m_TopElement.Q<Button>(ButtonBackName);
        buttonApply = m_TopElement.Q<Button>(ButtonApplyName);

        dropdownLanguage = m_TopElement.Q<DropdownField>(DropdownLanguageName);
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
        dropdownLanguage.RegisterCallback<ChangeEvent<string>>(onLocalChange);
        dropdownQualityGraphic.RegisterCallback<ChangeEvent<string>>(onQualityChange);
        dropdownResolution.RegisterCallback<ChangeEvent<string>>(onResolutionChange);
        toggleFullScreen.RegisterCallback<ClickEvent>(onFullScreenChange);
        sliderMasterVolume.RegisterCallback<ChangeEvent<float>>(onMasterVolumeChange);
        sliderMusicVolume.RegisterCallback<ChangeEvent<float>>(onMusicVolumeChange);
        sliderSFXVolume.RegisterCallback<ChangeEvent<float>>(onSFXVolumeChange);
        buttonApply.RegisterCallback<ClickEvent>(applySettingChange);
        buttonBack.RegisterCallback<ClickEvent>(closeSetting);
    }

    public override void Dispose()
    {
        base.Dispose();
        dropdownLanguage.UnregisterCallback<ChangeEvent<string>>(onLocalChange);
        dropdownQualityGraphic.UnregisterCallback<ChangeEvent<string>>(onQualityChange);
        dropdownResolution.UnregisterCallback<ChangeEvent<string>>(onResolutionChange);
        toggleFullScreen.UnregisterCallback<ClickEvent>(onFullScreenChange);
        sliderMasterVolume.UnregisterCallback<ChangeEvent<float>>(onMasterVolumeChange);
        sliderMusicVolume.UnregisterCallback<ChangeEvent<float>>(onMusicVolumeChange);
        sliderSFXVolume.UnregisterCallback<ChangeEvent<float>>(onSFXVolumeChange);
        buttonApply.UnregisterCallback<ClickEvent>(applySettingChange);
        buttonBack.UnregisterCallback<ClickEvent>(closeSetting);
        Hide();
    }

    protected override void SetInitialize()
    { 
        resolutions = Screen.resolutions;
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            localizationoptions.Add(locale.name);
        }

        for (int i = 0; i < resolutions.Length; ++i)
        {
            string resolutionString = resolutions[i].width + "x" + resolutions[i].height + " : " + resolutions[i].refreshRate;
            resolutionoptions.Add(resolutionString);
        }

        for (int i = 0; i < QualitySettings.names.Length; ++i)
        {
            qualityoptions.Add(QualitySettings.names[i]);
        }
        setCurrentSetting();
        adjusSetting();

        
    }

    private void setCurrentSetting()
    {
        currentLocalindex = settingData.LocalIndex;
        currentQualityIndex = settingData.QualityIndex;
        currentResolutionIndex = settingData.ResolutionIndex;
        isFullscreen = settingData.IsFullscreen;
        currentMusicVolume = settingData.MusicVolume;
        currentMasterVolume = settingData.MasterVolume;
        currentSFXVolume = settingData.SFXVolume;
    }

    private void adjusSetting()
    {
        dropdownLanguage.choices = localizationoptions;
        dropdownLanguage.value = localizationoptions[settingData.LocalIndex];
        dropdownResolution.choices = resolutionoptions;
        dropdownResolution.value = resolutionoptions[settingData.ResolutionIndex];
        dropdownQualityGraphic.choices = qualityoptions;
        dropdownQualityGraphic.value = qualityoptions[settingData.QualityIndex];
        toggleFullScreen.value = settingData.IsFullscreen;
        sliderMasterVolume.value = settingData.MasterVolume;
        sliderMusicVolume.value = settingData.MusicVolume;
        sliderSFXVolume.value = settingData.SFXVolume;
        isFullscreen = settingData.IsFullscreen;

        hasChange = false;
        buttonApply.SetEnabled(false);
    }

    private void onLocalChange(ChangeEvent<String> evt)
    {
        currentLocalindex = dropdownLanguage.index;
        enableButtonApply();
    }

    private void onQualityChange(ChangeEvent<String> evt) 
    {
        currentQualityIndex = dropdownQualityGraphic.index;
        enableButtonApply();
    }

    private void onResolutionChange(ChangeEvent<String> evt)
    {
        currentResolutionIndex = dropdownResolution.index;
        enableButtonApply();
    }

    private void onFullScreenChange(ClickEvent evt)
    {
        isFullscreen = !isFullscreen;
        enableButtonApply();
    }

    private void onMasterVolumeChange(ChangeEvent<float> evt)
    {
        currentMasterVolume = evt.newValue;
        enableButtonApply();
    }

    private void onMusicVolumeChange(ChangeEvent<float> evt)
    {
        currentMusicVolume = evt.newValue;
        enableButtonApply();
    }

    private void onSFXVolumeChange(ChangeEvent<float> evt)
    {
        currentSFXVolume = evt.newValue;
        AudioManage.Instance.SetGroupVolume("SFXVolume", currentSFXVolume);
        enableButtonApply();
    }

    private void enableButtonApply()
    {
        if (hasChange)
            return;
        buttonApply.SetEnabled(true);
        hasChange = true;
    }

    private void applySettingChange(ClickEvent evt)
    {
        if(!hasChange)
            return;

        settingData.LocalIndex = currentLocalindex;
        settingData.QualityIndex = currentQualityIndex;
        settingData.ResolutionIndex = currentResolutionIndex;
        settingData.IsFullscreen = isFullscreen;
        settingData.MusicVolume = currentMusicVolume;
        settingData.MasterVolume = currentMasterVolume;
        settingData.SFXVolume = currentSFXVolume;

        GameManager.SetSetting();
        hasChange = false;
        buttonApply.SetEnabled(false);
    }

    private void closeSetting(ClickEvent evt)
    {
        if (hasChange)
        {
            adjusSetting();
        }
        CloseSetting.RaiseEvent();
    }
}
