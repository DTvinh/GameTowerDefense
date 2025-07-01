using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBlueHp : MonoBehaviour, IDamageAble
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
            Invoke("Respawn", 15f);
        }
    }
    private void Respawn()
    {

        transform.position = transform.parent.transform.position;
        gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
