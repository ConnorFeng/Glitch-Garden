using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Game Timer")]
    [SerializeField]
    float levelTime = 10f;
    bool timeFinished = false;


    void Update()
    {
        if (timeFinished) return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        if (Time.timeSinceLevelLoad > levelTime)
        {
            timeFinished = true;
            FindObjectOfType<GameLevel>().TimeFinished();           
        }
    }

    public bool IsTimeFinished() { return timeFinished; }
  
}
