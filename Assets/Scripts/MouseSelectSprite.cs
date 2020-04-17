using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelectSprite : MonoBehaviour
{
    Vector2 mouseWorldPos;
    public void SetSelectedSprite(Sprite mouseSelectedSprite)
    { 
        GetComponent<SpriteRenderer>().sprite = mouseSelectedSprite;
    }
    public void ClearSelectedSprite()
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }
    void Start()
    {
        
    }
    void Update()
    {        
        mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));     
        transform.position = mouseWorldPos;

    }

}
