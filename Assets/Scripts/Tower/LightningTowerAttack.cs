using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTowerAttack : Attack
{
    [SerializeField] float radius = 7;
    [SerializeField] GameObject lightning;
    [SerializeField] Transform PointAttack;
    Animator animator;
    Tower lightningTower;
    float timer;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        lightningTower = GetComponent<Tower>();
    }


    void Update()
    {

        Hit();
    }

    public override void Hit()
    {
        timer -= Time.deltaTime;
        if (lightningTower.enemyPos != null && timer <= 0)
        {
            // Instantiate(lightning, enemyPos.position, Quaternion.identity);
            animator.SetTrigger("IsAttack");
            AudioManager.Instance.PlaySFX(AudioManager.Instance.linghtingTowerClip);
            GameObject lightningObj = ObjectPooling.Instance.GetObject(lightning);
            lightningObj.transform.position = lightningTower.enemyPos.position;
            lightningObj.SetActive(true);
            lightningTower.enemyPos.GetComponent<IDamageAble>().TakeDamage(damage);
            timer = speedAttack;
        }

    }



}
