using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowMachimeAttack : Attack
{


    [SerializeField] Transform pointAttack;
    [SerializeField] GameObject bullet;
    Tower tower;
    Animator animator;
    float timer = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        tower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        Throw();
    }



    public void Throw()
    {
        timer -= Time.deltaTime;
        if (tower.enemyPos != null && timer <= 0)
        {
            animator.SetTrigger("IsAttack");
            AudioManager.Instance.PlaySFX(AudioManager.Instance.FileBall);
            


            // Hit();
            timer = speedAttack;
            return;
        }
    }

    public override void Hit()
    {
        // Debug.Log("attack");
        if (tower.enemyPos == null) return;

        Vector3 direction = tower.enemyPos.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject ObjectBullet = Instantiate(bullet, pointAttack.position, Quaternion.identity);
        // GameObject ObjectBullet = ObjectPooling.Instance.getObject(bullet);
        // ObjectBullet.transform.position = pointAttack.position;
        FireBullet arrows = ObjectBullet.GetComponent<FireBullet>();
        arrows.SetTarget(tower.enemyPos);
        // ObjectBullet.SetActive(true);
        // Quaternion.Euler(new Vector3(0, 0, angle))
        // if(enemyPos)
    }

}
