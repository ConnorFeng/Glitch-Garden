﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        //Debug.Log(otherCollider.name);

        if(otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }



}
