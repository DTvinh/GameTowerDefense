using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMovement : Attack
{
    Tower towerWarrior;
    [SerializeField] float moveSpeed;
    Animator animator;

    // public Collider2D[] objectsToHit;
    [SerializeField] Transform attackPos;
    [SerializeField] Vector2 attckArea;
    public Transform enemyTarget = null;
    float timer = 0;
    void OnEnable()
    {
        towerWarrior = GetComponentInParent<Tower>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
        IsRuning();
    }


    private void IsRuning()
    {
        if (objectsToHit != null)
        {
            // if (objectsToHit[0] != null) 
            return;
        }

        if (towerWarrior.enemyPos == null)
        {
            animator.SetBool("IsRunning", false);
            return;
        }
        // if (objectsToHit.Length > 0) { return; }
        Flip();
        animator.SetBool("IsRunning", true);
        transform.position = Vector2.MoveTowards(transform.position, towerWarrior.enemyPos.position, moveSpeed * Time.deltaTime);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, attckArea);

    }

    private void Attack()
    {
        if (towerWarrior.enemyPos == null)
        {
            return;
        }



        objectsToHit = Physics2D.OverlapBox(attackPos.position, attckArea, 0, towerWarrior.enemyLayer);
        timer -= Time.deltaTime;


        if (objectsToHit != null && timer <= 0)
        {

            Hit();

            if (enemyTarget == null || !enemyTarget.gameObject.activeSelf)
                enemyTarget = objectsToHit.transform;
        }

    }

    public override void Hit()
    {

        if (enemyTarget == null) return;

        IDamageAble CanTakedamage = enemyTarget.GetComponent<IDamageAble>();
        Attack setTarget = enemyTarget.GetComponent<Attack>();
        if (setTarget != null) { setTarget.setAttack(this.transform); }

        if (CanTakedamage != null)
        {
            CanTakedamage.TakeDamage(damage);
            animator.SetTrigger("Attacking");
            AudioManager.Instance.PlaySFX(AudioManager.Instance.swordClip);

            timer = speedAttack;
            return;
        }
    }

    private void Flip()
    {
        if (towerWarrior.enemyPos == null)
        {
            return;
        }

        if (towerWarrior.enemyPos.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 0);

        }
        if (towerWarrior.enemyPos.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 0);

        }
    }



}
