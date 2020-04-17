using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    Color32 unSelectedColor = new Color32(84, 78, 78, 255);
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {

        CreateDefenderParent();

    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
       
        defender = defenderToSelect;
        //Debug.Log("DefenderSelected is" + defender.name);
    }
    public void ResetSelectedDefender()
    {
        defender = null;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && defender)
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }
           
        if (Input.GetMouseButtonDown(1))
        {
            var buttons = FindObjectsOfType<DefenderButton>();
            if (buttons.Length > 0) buttons[0].UnselectAllButtons();
            

            ResetSelectedDefender();
            FindObjectOfType<MouseSelectSprite>().ClearSelectedSprite();
        }
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarsCost();

        if(starDisplay.GetStars() >= defenderCost)
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        Vector2 worldGridPos = new Vector2(Mathf.RoundToInt(worldPos.x),Mathf.RoundToInt(worldPos.y));
        return worldGridPos;
    }

    private void SpawnDefender(Vector2 clickWorldPos)
    {
        if (!defender) return;
        Defender newDefender = Instantiate(defender, clickWorldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

}
