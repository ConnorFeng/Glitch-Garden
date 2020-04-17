using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        
        if(otherObject.GetComponent<Attacker>())
        {
            FindObjectOfType<HeartDisplay>().MinusHearts(1);
        }
        Destroy(otherObject);       
    }
}
