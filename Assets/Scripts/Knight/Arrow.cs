using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    float speed = 20;
    private Vector3 targetPos;
    float damage = 30;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = transform.right * speed;

    }
    public void SetDamage(float _damage)
    {
        damage = _damage;
    }
    private void FixedUpdate()
    {
        move();
    }
    public void SetTarget(Vector3 _target)
    {
        targetPos = _target;
    }
    private void move()
    {
        Vector3 moveDir = (targetPos - transform.position).normalized;
        // transform.position += moveDir * speed * Time.deltaTime;
        rb.velocity = moveDir * speed * 50 * Time.fixedDeltaTime;

        if (Vector3.Distance(transform.position, targetPos) <= 0.8f)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // Destroy(gameObject);
            // Debug.Log("hit");
            IDamageAble takeDamage = other.GetComponent<IDamageAble>();
            if (takeDamage != null)
            {
                takeDamage.TakeDamage(damage);
                gameObject.SetActive(false);

            }

        }
    }
}
