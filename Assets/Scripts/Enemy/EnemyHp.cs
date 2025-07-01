using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour, IDamageAble
{

    [SerializeField] float maxHealth;
    float health;
    HealthBar healthBar;

    private void OnEnable()
    {
        health = maxHealth;
        if (!healthBar) return;
        healthBar.UpdateHealthBar(health, maxHealth);

    }

    private void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);

    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        Bleed();
        DamagePopup(_damage);
        if (health <= 0)
        {
            // Destroy(gameObject);
            EffectDestroy();
            DropItemManager.Instance.DropRandomItem(transform.position);
            GameManager.Instance.OnEnemyDied(this.gameObject);
            gameObject.SetActive(false);
        }

    }

    private void EffectDestroy()
    {
        GameObject skullcap = ObjectPooling.Instance.GetObject(GameAssets.Instance.destroy);
        skullcap.transform.position = this.transform.position;
        skullcap.SetActive(true);
    }

    private void DamagePopup(float damage)
    {
        GameObject obj = ObjectPooling.Instance.GetObject(GameAssets.Instance.damagePopup);
        obj.transform.position = this.transform.position;
        obj.GetComponent<DamagePupop>().setUp(damage);
        obj.SetActive(true);
    }

    private void Bleed()
    {
        GameObject obj = ObjectPooling.Instance.GetObject(GameAssets.Instance.bleedEffect);
        obj.transform.position = this.transform.position;
        obj.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
