using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayDamage : Attack
{
    bool canTakeDamage = true;
    // float timer = 1;
    void Start()
    {

    }


    void Update()
    {

        Hit();

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            IDamageAble takeDamage = other.GetComponent<IDamageAble>();
            if (takeDamage != null)
            {

                StartCoroutine(attackHit(speedAttack, takeDamage));

            }

        }
    }
    IEnumerator attackHit(float time, IDamageAble takeDamage)
    {
        if (canTakeDamage)
        {

            takeDamage.TakeDamage(damage);
            canTakeDamage = !canTakeDamage;
            yield return new WaitForSeconds(time);
            canTakeDamage = !canTakeDamage;

        }

    }

}
