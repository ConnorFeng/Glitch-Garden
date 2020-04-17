using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField]
    float hearts;

    Text heartsText;

    public float GetHearts()
    {
        return hearts;
    }

    // Start is called before the first frame update
    void Start()
    {    
        hearts -= PlayerPrefsController.GetMasterDifficulty();
        heartsText = GetComponent<Text>();
        UpdateHeartsToDisplay();
    }

    private void UpdateHeartsToDisplay()
    {
        heartsText.text = hearts.ToString();

    }

    public void MinusHearts(int heartsDamage)
    {
        if (hearts > heartsDamage)
        {
            hearts -= heartsDamage;
            UpdateHeartsToDisplay();
        }
        else
        {
            FindObjectOfType<GameLevel>().HandleLoseCondition();           
        }

    }

}
