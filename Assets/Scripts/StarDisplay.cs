using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField]
    int stars = 100;

    Text starText;

    public int GetStars()
    {
        return stars;
    }

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateStarsToDisplay();
    }

    private void UpdateStarsToDisplay()
    {
        starText.text = stars.ToString();

    }

    public void AddStars(int starsToAdd)
    {
        stars += starsToAdd;
        UpdateStarsToDisplay();
    }

    public void SpendStars(int starsToSpend)
    {
        if(stars >= starsToSpend)
        {
            stars -= starsToSpend;
            UpdateStarsToDisplay();
        }
       
    }

}
