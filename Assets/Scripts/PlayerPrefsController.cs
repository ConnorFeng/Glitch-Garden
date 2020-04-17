using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUMN_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 1f;
    const float MAX_DIFFICULTY = 3f;

    public static void SetMasterVolume(float volume)
    {
        if (volume <= MAX_VOLUME && volume >= MIN_VOLUME)
        {
            //Debug.Log("volume set to" + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUMN_KEY, volume);
        }
        else
        {
            Debug.Log("Master volume is out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUMN_KEY);
    }

    public static void SetMasterDifficulty(float difficulty)
    {
        if (difficulty <= MAX_DIFFICULTY && difficulty >= MIN_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.Log("Master difficulty is out of range");
        }
    }
    public static float GetMasterDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }



}
