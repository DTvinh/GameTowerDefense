using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarrrorPurpleMovement : Attack
{
    [SerializeField] float moveSpeed;
    Animator animator;
    [SerializeField] Transform attackPos;
    [SerializeField] Vector2 attckArea;
    [SerializeField] float radius = 3;
    public LayerMask enemyLayer;

    public Transform enemyPos;
    public Transform enemyTarget = null;
    RaycastHit2D[] Enemy;
    float timer = 0;


    void OnEnable()
    {
        enemyTarget = null;
    }
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectEnemy();
        Attack();
        IsRuning();

    }
    private void IsRuning()
    {
        if (objectsToHit != null)
        {
            // if (objectsToHit[0] != null) return;
            return;
        }

        if (enemyPos == null)
        {
            animator.SetBool("IsRunning", false);
            return;
        }
        // if (objectsToHit.Length > 0) { return; }
        Flip();
        animator.SetBool("IsRunning", true);
        transform.position = Vector2.MoveTowards(transform.position, enemyPos.position, moveSpeed * Time.deltaTime);

    }

    private void DetectEnemy()
    {
        Enemy = Physics2D.CircleCastAll(transform.position, radius, Vector2.right, 0f, enemyLayer);

        if (Enemy.Length > 0)
        {
            enemyPos = Enemy[0].transform;
            // Debug.Log(enemyPos?.name);
            return;
        }
        enemyPos = null;
        return;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, attckArea);
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    private void Attack()
    {
        if (enemyPos == null)
        {
            return;
        }
        objectsToHit = Physics2D.OverlapBox(attackPos.position, attckArea, 0, enemyLayer);
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
            // objectsToHit.GetComponent<EnemyMovement>().setMovement(false);
            timer = speedAttack;
            return;
        }
    }

    private void Flip()
    {
        if (enemyPos == null)
        {
            return;
        }

        if (enemyPos.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 0);

        }
        if (enemyPos.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
