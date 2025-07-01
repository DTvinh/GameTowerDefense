using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{



    [SerializeField] protected float damage;
    [SerializeField] protected float speedAttack;
    public Collider2D objectsToHit;
    public Transform attackTarget;


    public virtual void Hit()
    {

    }

    public void SetDamage(float _damage)
    {
        damage = _damage;


    }

    public void setAttack(Transform _attackTarget)
    {

        attackTarget = _attackTarget;

    }
}
