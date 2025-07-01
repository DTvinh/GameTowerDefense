using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Attack
{
    [SerializeField] Transform attackPos;
    [SerializeField] Vector2 attckArea;
    Animator animator;

    public LayerMask targetAttack;
    float timer = 0;
    bool canAttack;
    EnemyMovement enemyMovement;
    void OnEnable()
    {
        attackTarget = null;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPos.position, attckArea);

    }


    private void Attack()
    {

        timer -= Time.deltaTime;

        if (attackTarget != null)
        {
            if (!attackTarget.gameObject.activeSelf)
            {
                attackTarget = null;
                return;
            }

            IDamageAble CanTakedamage = attackTarget.GetComponent<IDamageAble>();

            if (CanTakedamage != null && timer <= 0)
            {
                CanTakedamage.TakeDamage(damage);
                AudioManager.Instance.PlaySFX(AudioManager.Instance.enemyHitClip);

                animator.SetTrigger("Attacking");
                timer = speedAttack;
            }
            // canAttack = false;
        }
    }

    private void Flip()
    {

        if (attackTarget == null)
        {
            return;
        }

        if (attackTarget.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 0);

        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);

        }
    }
}
