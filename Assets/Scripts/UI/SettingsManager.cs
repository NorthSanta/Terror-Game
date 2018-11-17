using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour {

    private static bool created = false;

    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDrowpdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;
    public Slider soundVolumeSlider;
    public Button applyButton;
    public Button resetButton;

    public AudioSource musicSource;
    public Resolution[] resolutions;
    private GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDrowpdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVsyncChange(); });
        soundVolumeSlider.onValueChanged.AddListener(delegate { OnSoundVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });
        resetButton.onClick.AddListener(delegate { OnResetButtonClick(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }
    // Use this for initialization
    void Awake () {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
    }

    public void OnFullScreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDrowpdown.value;
    }

    public void OnAntialiasingChange()
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow(2f, antialiasingDropdown.value);
        gameSettings.antialiasing = antialiasingDropdown.value;
    }

    public void OnVsyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }

    public void OnSoundVolumeChange()
    {
        musicSource.volume = gameSettings.musicVolume = soundVolumeSlider.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void OnResetButtonClick()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SaveSettings()
    {
        PlayerPrefs2.SetBool("fullscreen",  gameSettings.fullscreen);
        PlayerPrefs.SetInt("resolution", gameSettings.resolutionIndex);
        PlayerPrefs.SetInt("textureQuality", gameSettings.textureQuality);
        PlayerPrefs.SetInt("antialiasing", gameSettings.antialiasing);
        PlayerPrefs.SetInt("vSync", gameSettings.vSync);
        PlayerPrefs.SetFloat("volume", gameSettings.musicVolume);

        //string jsonData = JsonUtility.ToJson(gameSettings, true);
        //File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
        Debug.Log("Settings saved");
    }

    public void LoadSettings()
    {
        //if (File.Exists(Application.persistentDataPath + "/gamesettings.json"))
        //{    //Check if file exists in order to be able to load it
        //string jsonData = File.ReadAllText(Application.persistentDataPath + "/gamesettings.json");
        //gameSettings = JsonUtility.FromJson<GameSettings>(jsonData);
        Debug.Log("Settings Loaded");

        if (PlayerPrefs.HasKey("volume"))
            gameSettings.musicVolume = PlayerPrefs.GetFloat("volume");
        else
            gameSettings.musicVolume = soundVolumeSlider.value;
        if (PlayerPrefs.HasKey("vSync"))
            gameSettings.vSync = PlayerPrefs.GetInt("vSync");
        if (PlayerPrefs.HasKey("antialiasing"))
            gameSettings.antialiasing = PlayerPrefs.GetInt("antialiasing");
        if (PlayerPrefs.HasKey("textureQuality"))
            gameSettings.textureQuality = PlayerPrefs.GetInt("textureQuality");
        if (PlayerPrefs.HasKey("resolution"))
            gameSettings.resolutionIndex = PlayerPrefs.GetInt("resolution");
        if (PlayerPrefs.HasKey("fullscreen"))
            gameSettings.fullscreen = PlayerPrefs2.GetBool("fullscreen");

        soundVolumeSlider.value = gameSettings.musicVolume;
        vSyncDropdown.value = gameSettings.vSync;
        antialiasingDropdown.value = gameSettings.antialiasing;
        textureQualityDrowpdown.value = gameSettings.textureQuality;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        fullscreenToggle.isOn = gameSettings.fullscreen;
        Screen.fullScreen = gameSettings.fullscreen;

        resolutionDropdown.RefreshShownValue();
    }
}
