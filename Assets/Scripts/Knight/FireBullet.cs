using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform targetPos;
    [SerializeField] private Transform explosion;

    float damage = 80;
    Rigidbody2D rb;
    Vector3 velocity;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        velocity = ThrowObject.CalculateArc(transform, targetPos);
    }
    private void OnEnable()
    {
        // velocity = ThrowObject.CalculateArc(transform, targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Fall();
    }

    private void move()
    {



        velocity.y -= 9.8f * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;

        if (velocity.magnitude > 0)
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 100);

        }

    }
    private void Fall()
    {
        if (targetPos == null) return;

        if (velocity.y <= 0 && transform.position.y <= targetPos.position.y)
        {

            GameObject expl = ObjectPooling.Instance.GetObject(explosion.gameObject);
            expl.transform.position = transform.position;
            expl.SetActive(true);
            Explosion();
            Destroy(gameObject);


        }
    }

    private void Explosion()
    {
        Collider2D[] objectsToHit = Physics2D.OverlapBoxAll(transform.position, new Vector2(2.2f, 2.2f), 0, SkillsManager.Instance.AttackLayer);

        if (objectsToHit.Length > 0)
        {
            for (var i = 0; i < objectsToHit.Length; i++)
            {
                IDamageAble CanTakedamage = objectsToHit[i].GetComponent<IDamageAble>();
                if (CanTakedamage != null)
                {
                    CanTakedamage.TakeDamage(damage);
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.fireBallExplosion);
                }

            }
        }
    }



    public void SetTarget(Transform _target)
    {
        targetPos = _target;

    }
}
