using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DropBullet : SupportSkills
{

    private float speed;
    public GameObject Explosion_DropBullet;
    float damage = 100;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        transform.position -= new Vector3(0, 20f) * Time.deltaTime;
        if (transform.position.y <= positionTarget.y)
        {
            GameObject obj = ObjectPooling.Instance.GetObject(Explosion_DropBullet);
            obj.transform.position = this.transform.position;
            obj.SetActive(true);
            Attack();
            Observer.Notify(CONSTANT.CAMERA_SHAHKE);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.fireBallExplosion);
            Destroy(gameObject);
        }
    }

    protected override void Attack()
    {
        Collider2D[] objectsToHit = Physics2D.OverlapBoxAll(this.transform.position, new Vector2(0.7f, 0.7f), 0, SkillsManager.Instance.AttackLayer);

        if (objectsToHit.Length > 0)
        {
            for (var i = 0; i < objectsToHit.Length; i++)
            {
                IDamageAble CanTakedamage = objectsToHit[i].GetComponent<IDamageAble>();
                if (CanTakedamage != null)
                {
                    CanTakedamage.TakeDamage(damage);
                }

            }


        }
    }
    public override async void SpawnPrefabs(Vector3 PoinSpawn)
    {
        for (int i = 0; i < 7; i++)
        {

            Vector2 randomPosSpawn = new Vector2(PoinSpawn.x + Random.Range(-0.5f, 0.5f), PoinSpawn.y + Random.Range(-0.5f, 0.5f));
            GameObject obj = Instantiate(GameAssets.Instance.DragBullet, new Vector3(randomPosSpawn.x, randomPosSpawn.y + 10), Quaternion.identity);
            obj.GetComponent<SupportSkills>().SetPositionTarget(randomPosSpawn);
            await Task.Delay((int)(0.2f * 1000));
        }
    }

    // public  async void SpawnPrefabs(Vector3 PoinSpawn)
    // {
    //     for (int i = 0; i < 7; i++)
    //     {
    //         Vector2 randomPosSpawn = new Vector2(PoinSpawn.x + Random.Range(-2, 2), PoinSpawn.y + Random.Range(-2, 2));
    //         Instantiate(GameAssets.Instance.DragBullet, randomPosSpawn, Quaternion.identity);
    //         await Task.Delay((int)(0.02 * 1000)); 
    //     }
    // }


}
