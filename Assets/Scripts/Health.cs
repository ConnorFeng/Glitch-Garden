using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float health = 100f;
    [SerializeField]
    GameObject deathVFX;

    GameObject deathVFXParent;

    const string DEATHVFX_PARENT_NAME = "DeathVFXs";

    private void Start()
    {
        CreateDeathVFXParent();
    }

    private void CreateDeathVFXParent()
    {
        deathVFXParent = GameObject.Find(DEATHVFX_PARENT_NAME);
        if (!deathVFXParent) deathVFXParent = new GameObject(DEATHVFX_PARENT_NAME);
    }

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
            //Debug.Log(gameObject.name + "is destroyed");
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        deathVFXObject.transform.parent = deathVFXParent.transform;

        Destroy(deathVFXObject, 1f);
    }
}
