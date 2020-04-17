using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starsCost = 100;
   



    public int GetStarsCost()
    {
        return starsCost;
    }

    public void AddStars(int starsToAdd)
    {
        FindObjectOfType<StarDisplay>().AddStars(starsToAdd);
    }

}
