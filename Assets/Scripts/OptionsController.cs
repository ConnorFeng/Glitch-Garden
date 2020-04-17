using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    Slider volumeSlider, difficultySlider;
    [SerializeField]
    float defaultVolume = 0.6f;
    [SerializeField]
    float defaultDifficulty = 1f;


    // Start is called before the first frame update
    void Start()
    {
       
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetMasterDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found...pls start from splash screen");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetMasterDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadStartScreen();
    }

    public void SetToDefaultSetting()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }


}
