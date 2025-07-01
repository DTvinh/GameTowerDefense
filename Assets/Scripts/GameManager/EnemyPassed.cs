using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPassed : MonoBehaviour
{



    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GameManager.Instance.OnEnemyDied(other.gameObject);
            other.gameObject.SetActive(false);
            GameManager.Instance.CountEnemyPassed();


        }
    }


}
