using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefaultSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsController.SetMasterDifficulty(1f);
        PlayerPrefsController.SetMasterVolume(0.6f);
    }

}
