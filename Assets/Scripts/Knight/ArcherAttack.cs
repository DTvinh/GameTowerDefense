using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArcherAttack : Attack
{

    [SerializeField] Transform pointAttack;
    [SerializeField] GameObject arrow;
    Animator animator;
    float timer = 0;
    Tower archerTower;
    void Start()
    {
        animator = GetComponent<Animator>();
        archerTower = GetComponentInParent<Tower>();

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Flip();
    }



    public void Attack()
    {
        timer -= Time.deltaTime;

        if (archerTower.enemyPos != null && timer <= 0)
        {

            // Debug.Log(enemyPos?.name);
            animator.SetTrigger("IsAttack");
            Hit();
            timer = speedAttack;
            return;
        }



    }


    private void Flip()
    {
        if (archerTower.enemyPos == null)
        {
            return;
        }
        if (archerTower.enemyPos.position.x < transform.position.x)
        {
            transform.parent.localScale = new Vector3(-1, 1, 0);

        }
        if (archerTower.enemyPos.position.x > transform.position.x)
        {
            transform.parent.localScale = new Vector3(1, 1, 0);

        }
    }
    public override void Hit()
    {
        // Debug.Log("attack");
        if (archerTower.enemyPos == null) return;

        
        Vector3 direction = archerTower.enemyPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject ArrowObj = ObjectPooling.Instance.GetObject(arrow);
        ArrowObj.transform.position = pointAttack.position;
        ArrowObj.SetActive(true);
        ArrowObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Arrow arrows = ArrowObj.GetComponent<Arrow>();
        arrows.SetDamage(damage);
        arrows.SetTarget(archerTower.enemyPos.position);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.arrowClicp);

        // GameObject Arrow = Instantiate(arrow, pointAttack.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        // if(enemyPos)
    }
}
