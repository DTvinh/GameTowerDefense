using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHP : MonoBehaviour, IDamageAble
{

    [SerializeField] float maxHealth;

    float health;

    void OnEnable()
    {
        health = maxHealth;
    }

    private void Start()
    {
        health = maxHealth;

    }
    public void TakeDamage(float _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }
}
