using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField]
    Defender defenderPrefab;
    Color32 unSelectedColor = new Color32(84, 78, 78, 137);

    MouseSelectSprite mouseSelectSprite;

    Vector2 mouseWorldPos;

    private void Start()
    {  
        LabelButtonsWithCost();
        mouseSelectSprite = FindObjectOfType<MouseSelectSprite>();
    }

    private void LabelButtonsWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetStarsCost().ToString(); 

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnselectAllButtons();

            GetComponent<SpriteRenderer>().color = Color.white;
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);

            var mouseSelectedSprite = GetComponent<SpriteRenderer>().sprite;
            mouseSelectSprite.SetSelectedSprite(mouseSelectedSprite);

        }

        if (Input.GetMouseButtonDown(1))
        {
            UnselectAllButtons();
            FindObjectOfType<DefenderSpawner>().ResetSelectedDefender();

            FindObjectOfType<MouseSelectSprite>().ClearSelectedSprite();
        }

    }

    public void UnselectAllButtons()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = unSelectedColor;
        }
    }



   
}
