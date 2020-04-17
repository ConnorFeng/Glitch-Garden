using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed =1f;
    Animator animator;
    GameObject currentTarget;

    //state variables
    bool isAttacking = false;

    // Start is called before the first frame update

    private void Awake()
    {
        FindObjectOfType<GameLevel>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        if(FindObjectOfType<GameLevel>()) FindObjectOfType<GameLevel>().AttackerKilled();

    }


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        UpdateAnimationState();

    }

    private void Move()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget) GetComponent<Animator>().SetBool("isAttacking", false);
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)return;
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);

        }

    }

}
